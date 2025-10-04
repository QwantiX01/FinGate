namespace Authentication.Models;

/// <summary>
/// Represents a pair of authentication tokens consisting of an access token and a refresh token.
/// Used for implementing token-based authentication in the system.
/// </summary>
public class TokenPair(string accessToken, string refreshToken)
{
    /// <summary>
    /// Gets or sets the access token used for authenticating API requests.
    /// </summary>
    public string AccessToken { get; set; } = accessToken;

    /// <summary>
    /// Gets or sets the refresh token used to get a new access token when the current one expires.
    /// </summary>
    public string RefreshToken { get; set; } = refreshToken;

    /// <summary>
    /// Determines whether the current access token has expired.
    /// </summary>
    /// <returns>True if the access token has expired; otherwise, false.</returns>
    public bool IsExpired()
    {
        throw new NotImplementedException();
    }
}