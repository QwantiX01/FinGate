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
    /// Checks if a user with the specified username exists.
    /// </summary>
    /// <param name="username">The username to check (primary key).</param>
    /// <returns>True if the user exists; otherwise, false.</returns>
    Task<bool> ExistsAsync(string username);

    /// <summary>
    /// Creates a new user in the repository.
    /// </summary>
    /// <param name="user">The user entity to create.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateAsync(User user);

    /// <summary>
    /// Updates an existing user in the repository.
    /// </summary>
    /// <param name="user">The user entity with updated information.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(User user);

    /// <summary>
    /// Deletes a user from the repository.
    /// </summary>
    /// <param name="username">The username of the user to delete (primary key).</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteAsync(string username);

    /// <summary>
    /// Asynchronously retrieves the password hash for a specified user.
    /// </summary>
    /// <param name="username">The username of the user whose password hash is to be retrieved.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the user's password hash as a string, 
    /// or null/empty if the user is not found.
    /// </returns>
    Task<string?> GetUserPasswordHash(string username);
}