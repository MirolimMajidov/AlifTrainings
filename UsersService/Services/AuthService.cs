using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UsersService.DTOs;
using UsersService.Infrastructure.Configs;
using UsersService.Models;
using UsersService.Repositories;
using UsersService.Services;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Users.API.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly AuthOptions _authOptions;
    private readonly ICRUDRepository<RefreshToken> _refreshtokenRepository;

    public AuthService(IUserService userService, ICRUDRepository<RefreshToken> refreshtokenRepository, AuthOptions authOptions)
    {
        _userService = userService;
        _authOptions = authOptions;
        _refreshtokenRepository = refreshtokenRepository;
    }

    public async Task<(TokenInfoDto tokenInfoDto, string errorMessage)> GenerateTokenAsync(LoginDto loginDto,
        CancellationToken cancellationToken = default)
    {
        var user = _userService.GetEntities()
            .SingleOrDefault(u => u.UserName == loginDto.Username && u.Password == loginDto.Password);
        if (user is null)
            return (null, "User not found");
       
        return await GenerateJwtAsync(user, cancellationToken);
    }

    public async Task<(TokenInfoDto tokenInfoDto, string errorMessage)> RefreshTokenAsync(
        RefreshTokenDto refreshTokenDto,
        CancellationToken cancellationToken = default)
    {
        var refreshToken = _refreshtokenRepository.GetEntities().AsQueryable().Include(rt => rt.User)
            .SingleOrDefault(u => u.Token == refreshTokenDto.RefreshToken);
        if (refreshToken?.User is null)
            return (null, "No active token");
     
        _refreshtokenRepository.Delete(refreshToken);
      
        return await GenerateJwtAsync(refreshToken.User, cancellationToken);

    }

    private async Task<(TokenInfoDto tokenInfoDto, string errorMessage)> GenerateJwtAsync(User user,
        CancellationToken cancellationToken = default)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Name, user.UserName ?? string.Empty)
        };
        
        cancellationToken.ThrowIfCancellationRequested();
        
        var roles = user.UserRoles.Select(r=>r.Role?.Name).ToArray();
        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));
        
        var key = _authOptions.GetSymmetricSecurityKey();
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expireTime = DateTime.Now.AddMinutes(_authOptions.LifetimeOfAccessToken);
        
        var jwt = new JwtSecurityToken(
            issuer: _authOptions.Issuer,
            audience: _authOptions.Audience,
            claims: claims,
            expires: expireTime,
            signingCredentials: credentials);
        
        cancellationToken.ThrowIfCancellationRequested();
        
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
        var refreshToken = Guid.NewGuid().ToString();
        
        user.RefreshTokens.Add(new RefreshToken
        {
            UserId = user.Id,
            Token = refreshToken,
            ExpireAt = DateTime.Now.AddDays(_authOptions.LifetimeOfRefreshToken)
        });
        await _userService.SaveAsync(cancellationToken);
        
        var token = new TokenInfoDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpireTime = expireTime
        };
        return (token, string.Empty);
    }
}