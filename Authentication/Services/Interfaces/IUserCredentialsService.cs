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
    /// <param name="token">The refresh token to store.</param>
    Task StoreRefreshTokenAsync(string username, string token);

    /// <summary>
    /// Validates the refresh token associated with the provided access token for the specified user.
    /// </summary>
    /// <param name="username">The username (primary key).</param>
    /// <param name="token">The access token to validate against.</param>
    /// <returns>True if the refresh token is valid; otherwise, false.</returns>
    Task<bool> ValidateRefreshTokenAsync(string username, string token);
}