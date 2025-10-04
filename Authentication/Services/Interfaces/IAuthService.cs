using Authentication.Models;

namespace Authentication.Services.Interfaces;

/// <summary>
/// Main authentication service that orchestrates user registration, login, and token refresh.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Registers a new user with the provided credentials and generates authentication tokens.
    /// </summary>
    /// <param name="username">The username for the new account.</param>
    /// <param name="password">The password for the new account.</param>
    /// <returns>A token pair containing access and refresh tokens.</returns>
    Task<TokenPair> RegisterAsync(string username, string password);

    /// <summary>
    /// Authenticates a user with the provided credentials and generates new tokens.
    /// </summary>
    /// <param name="username">The username of the account.</param>
    /// <param name="password">The password of the account.</param>
    /// <returns>A token pair containing access and refresh tokens.</returns>
    Task<TokenPair> LoginAsync(string username, string password);

    /// <summary>
    /// Refreshes the authentication tokens using a valid refresh token.
    /// </summary>
    /// <param name="username">The username of the account.</param>
    /// <param name="refreshToken">The current refresh token.</param>
    /// <returns>A new token pair containing updated access and refresh tokens.</returns>
    Task<TokenPair> RefreshTokenAsync(string username, string refreshToken);

    /// <summary>
    /// Logs out a user and invalidates their authentication tokens.
    /// </summary>
    /// <param name="username">The username of the account to log out.</param>
    Task LogoutAsync(string username);
}
