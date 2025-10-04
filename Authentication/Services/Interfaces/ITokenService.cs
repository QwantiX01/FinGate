namespace Authentication.Services.Interfaces;

/// <summary>
/// Service for handling JWT token generation and validation.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Generates a JWT access token for the specified user.
    /// </summary>
    /// <param name="username">The username of the user (primary key).</param>
    /// <param name="roles">Optional collection of user roles to include in the token.</param>
    /// <returns>A JWT access token string.</returns>
    string GenerateToken(string username, IEnumerable<string>? roles = null);
    
    /// <summary>
    /// Generates a secure refresh token.
    /// </summary>
    /// <returns>A cryptographically secure refresh token string.</returns>
    string GenerateRefreshToken();
    
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