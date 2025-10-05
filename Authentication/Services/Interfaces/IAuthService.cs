using Authentication.Contracts;
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
    /// <param name="registerContract">The registration data containing username, password, and email.</param>
    /// <returns>A token pair containing access and refresh tokens.</returns>
    Task<TokenPair> RegisterAsync(UserRegisterContract registerContract);

    /// <summary>
    /// Authenticates a user with the provided credentials and generates new tokens.
    /// </summary>
    /// <param name="loginContract">The login data containing username and password.</param>
    /// <returns>A token pair containing access and refresh tokens.</returns>
    Task<TokenPair> LoginAsync(UserLoginContract loginContract);

    /// <summary>
    /// Refreshes the authentication tokens using a valid refresh token.
    /// </summary>
    /// <param name="refreshContract">The refresh data containing username and current refresh token.</param>
    /// <returns>A new token pair containing updated access and refresh tokens.</returns>
    Task<TokenPair> RefreshTokenAsync(TokenRefreshContract refreshContract);

    /// <summary>
    /// Logs out a user and invalidates their authentication tokens.
    /// </summary>
    Task LogoutAsync();
}
