// Authentication/Data/UserRepository.cs

using Authentication.Data.Interfaces;
using Authentication.Models;

namespace Authentication.Services;

public class UserRepository : IUserRepository
{
    // Тимчасове in-memory сховище
    private readonly Dictionary<string, User> _users = new();

    public Task<User?> GetByUsernameAsync(string username)
    {
        _users.TryGetValue(username, out var user);
        return Task.FromResult(user);
    }

    public Task CreateAsync(User user)
    {
        _users[user.Username] = user;
        return Task.CompletedTask;
    }
}