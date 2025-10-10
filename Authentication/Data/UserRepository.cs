using Authentication.Data.Interfaces;
using Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data;

public class UserRepository(AuthDbContext authDbContext) : IUserRepository
{
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await authDbContext.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }


    public async Task<bool> ExistsAsync(string username)
    {
        return await authDbContext.Users
            .AnyAsync(u => u.Username == username);
    }


    public async Task CreateAsync(User user)
    {
        await authDbContext.Users.AddAsync(user);
        await authDbContext.SaveChangesAsync();
    }


    public async Task UpdateAsync(User user)
    {
        authDbContext.Users.Update(user);
        await authDbContext.SaveChangesAsync();
    }


    public async Task DeleteAsync(string username)
    {
        var userToDelete = await GetByUsernameAsync(username);
        if (userToDelete != null)
        {
            authDbContext.Users.Remove(userToDelete);
            await authDbContext.SaveChangesAsync();
        }
    }

    public async Task<string?> GetUserPasswordHash(string username)
    {
        var user = await GetByUsernameAsync(username);
        return user?.PasswordHash;
    }
}