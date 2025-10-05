using Authentication.Models;

namespace Authentication.Services.Interfaces;

/// <summary>
/// Service for handling JWT token generation and validation.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Generates a JWT access token for the specified user.
    /// </summary>
    /// <param name="user">The user to generate token for.</param>
    /// <returns>A JWT access token string.</returns>
    string GenerateToken(User user);
    
    /// <summary>
    /// Generates a secure refresh token for the specified user.
    /// </summary>
    /// <param name="user">The user to generate refresh token for.</param>
    /// <returns>A cryptographically secure refresh token string.</returns>
    string GenerateRefreshToken(User user);
    
    /// <summary>
    /// Validates the provided JWT token.
    /// </summary>
    /// <param name="token">The JWT token to validate.</param>
    /// <returns>True if the token is valid and not expired; otherwise, false.</returns>
    bool ValidateToken(string token);
    
    /// <summary>
    /// Extracts the username from the token claims.
    /// </summary>
    /// <param name="token">The JWT token to parse.</param>
    /// <returns>The username if found; otherwise, null.</returns>
    string? GetUsernameFromToken(string token);
    
    /// <summary>
    /// Retrieves the expiration date of the token.
    /// </summary>
    /// <param name="token">The JWT token to parse.</param>
    /// <returns>The expiration date if found; otherwise, null.</returns>
    DateTime? GetTokenExpirationDate(string token);
}