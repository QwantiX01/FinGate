using Authentication.Models;

namespace Authentication.Services.Interfaces;

/// <summary>
/// Service for managing user credentials and token validation.
/// Uses username as the primary key for user identification.
/// </summary>
public interface IUserCredentialsService
{
    /// <summary>
    /// Validates the provided password against the stored credentials for the specified user.
    /// </summary>
    /// <param name="username">The username (primary key).</param>
    /// <param name="password">The password to validate.</param>
    /// <returns>True if the password is valid; otherwise, false.</returns>
    Task<bool> ValidateUserPasswordAsync(string username, string password);

    /// <summary>
    /// Stores a token pair (access and refresh tokens) for the specified user.
    /// </summary>
    /// <param name="username">The username (primary key).</param>
    /// <param name="tokens">The token pair to store.</param>
    Task StoreTokenPairAsync(string username, TokenPair tokens);

    /// <summary>
    /// Validates the refresh token associated with the provided access token for the specified user.
    /// </summary>
    /// <param name="accessToken">The access token to validate against.</param>
    /// <returns>True if the refresh token is valid; otherwise, false.</returns>
    Task<bool> ValidateRefreshTokenAsync(string accessToken);
}