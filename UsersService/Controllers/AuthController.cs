using Microsoft.AspNetCore.Mvc;
using Users.API.Services;
using UsersService.DTOs;

namespace UsersService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;
    private ILogger<AuthController> _logger;

    public AuthController(IAuthService service, ILogger<AuthController> logger)
    {
        _service = service;
        _logger = logger;
    }
    
    /// <summary>
    /// Generate token for getting access to system.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Return generated token information.</returns>
    [HttpPost("token")]
    [ProducesResponseType(typeof(TokenInfoDto), 200)]
    public async Task<IActionResult> GenerateToken([FromBody] LoginDto loginDto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            (TokenInfoDto tokenInfoDto, string errorMessage) =
                await _service.GenerateTokenAsync(loginDto, cancellationToken);
            if (tokenInfoDto is null)
                return BadRequest(errorMessage);

            return Ok(tokenInfoDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while login");
            return BadRequest("An error occurred while login.");
        }
    }

    /// <summary>
    /// Re-generate token for getting access to system.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Return generated token information.</returns>
    [HttpPost("refresh-token")]
    [ProducesResponseType(typeof(TokenInfoDto), 200)]
    public async Task<IActionResult> Login([FromBody] RefreshTokenDto refreshTokenDto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            (TokenInfoDto tokenInfoDto, string errorMessage) =
                await _service.RefreshTokenAsync(refreshTokenDto, cancellationToken);
            if (tokenInfoDto is null)
                return BadRequest(errorMessage);

            return Ok(tokenInfoDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while refresh token");
            return BadRequest("An error occurred while refresh token.");
        }
    }
}