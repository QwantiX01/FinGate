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
    public required string Username { get; set; }
    
    /// <summary>
    /// Gets or sets the hashed password.
    /// </summary>
    public required string PasswordHash { get; set; }
    
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
}
