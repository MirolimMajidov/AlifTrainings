using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace UsersService.Infrastructure.Configs;


/// <summary>
/// Represents the authentication options used for generating and validating JWTs.
/// </summary>
public record AuthOptions
{
    /// <summary>
    /// Gets the issuer of the JWT. Typically, this is the authentication service or server issuing the token.
    /// </summary>
    public string Issuer { get; init; } = "AuthService";

    /// <summary>
    /// Gets the audience of the JWT. This is the intended recipient of the token, usually the API or service that will consume the token.
    /// </summary>
    public string Audience { get; init; } = "CBS";

    /// <summary>
    /// Gets the security key used to sign the JWT. This should be a secure, secret key.
    /// </summary>
    public string SecurityKey { get; init; } = "2EC1EE51-1100-4347-BF22-EEB6CB8B0695";

    /// <summary>
    /// Gets the lifetime of the access token in minutes. This defines how long the token is valid before it expires.
    /// </summary>
    public int LifetimeOfAccessToken { get; init; } = 30;

    /// <summary>
    /// Gets the lifetime of the refresh token in hours. This defines how long the refresh token is valid before it expires.
    /// </summary>
    public int LifetimeOfRefreshToken { get; init; } = 12;

    /// <summary>
    /// Generates a symmetric security key based on the KEY property. This key is used to sign and validate the JWT.
    /// </summary>
    /// <returns>A <see cref="SymmetricSecurityKey"/> object generated from the KEY.</returns>
    public SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new (Encoding.UTF8.GetBytes(SecurityKey));
}
