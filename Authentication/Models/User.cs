namespace Authentication.Models;

/// <summary>
/// Represents a user in the authentication system.
/// Uses username as the primary key.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets the username (primary key).
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the hashed password.
    /// </summary>
    public string PasswordHash { get; set; }

    /// <summary>
    /// Gets or sets the user's email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the user's roles.
    /// </summary>
    public ICollection<string> Roles { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the date and time when the user was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the date and time when the user was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets whether the user account is active.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Gets or sets the date and time of the last login.
    /// </summary>
    public DateTime? LastLoginAt { get; set; }

    /// <summary>
    /// Gets or sets the refresh token for the user.
    /// This token is used to obtain a new access token.
    /// </summary>
    public string? RefreshToken { get; set; }

    /// <summary>
    /// Gets or sets the expiry date and time for the refresh token.
    /// </summary>
    public DateTime? RefreshTokenExpiryTime { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="username">The username for the user.</param>
    /// <param name="passwordHash">The hashed password for the user.</param>
    /// <param name="email">The email address for the user.</param>
    public User(string username, string passwordHash, string? email)
    {
        Username = username;
        PasswordHash = passwordHash;
        Email = email;
        Roles = [];
        CreatedAt = DateTime.UtcNow;
        IsActive = false;
    }
}