using Authentication.Models;

namespace Authentication.Data.Interfaces;

/// <summary>
/// Repository for user data persistence and retrieval.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Retrieves a user by their username asynchronously.
    /// </summary>
    /// <param name="username">The username of the user to retrieve (primary key).</param>
    /// <returns>The user if found; otherwise, null.</returns>
    Task<User?> GetByUsernameAsync(string username);
    
    /// <summary>
    /// Creates a new user in the repository.
    /// </summary>
    /// <param name="user">The user entity to create.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateAsync(User user);
    
}