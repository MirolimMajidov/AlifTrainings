using UsersService.DTOs;

namespace Users.API.Services;

/// <summary>
/// Interface for authentication service.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Generates a JWT token for the provided login credentials.
    /// </summary>
    /// <param name="loginDto">The login data transfer object containing username and password.</param>
    /// <returns>
    /// A tuple containing the generated token information and an error message if the operation fails.
    /// </returns>
    Task<(TokenInfoDto tokenInfoDto, string errorMessage)> GenerateTokenAsync(LoginDto loginDto,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Generates a new JWT token using the provided refresh token.
    /// </summary>
    /// <param name="refreshTokenDto">The data transfer object containing the refresh token.</param>
    /// <returns>
    /// A tuple containing the generated token information and an error message if the operation fails.
    /// </returns>
    Task<(TokenInfoDto tokenInfoDto, string errorMessage)> RefreshTokenAsync(RefreshTokenDto refreshTokenDto,
        CancellationToken cancellationToken = default);
}