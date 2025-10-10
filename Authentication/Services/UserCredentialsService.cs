using Authentication.Data.Interfaces;
using Authentication.Models;
using Authentication.Models.Exceptions;
using Authentication.Services.Interfaces;

namespace Authentication.Services;

public class UserCredentialsService(IUserRepository userRepository, IEncryptionService encryptionService)
    : IUserCredentialsService
{
    public async Task<bool> ValidateUserPasswordAsync(string username, string password)
    {
        var user = await userRepository.GetByUsernameAsync(username);
        if (user == null)
            throw new UserDoesNotExistsException(username);

        var passwordHash = encryptionService.EncryptString(password);
        return user.PasswordHash == passwordHash;
    }

    public async Task StoreRefreshTokenAsync(string username, string token)
    {
        var user = await userRepository.GetByUsernameAsync(username);
        if (user == null)
            throw new UserDoesNotExistsException(username);

        user.RefreshToken = token;
        await userRepository.UpdateAsync(user);
    }

    public async Task<bool> ValidateRefreshTokenAsync(string username, string token)
    {
        var user = await userRepository.GetByUsernameAsync(username);
        if (user == null)
            throw new UserDoesNotExistsException(username);

        return user.RefreshToken == token;
    }
}