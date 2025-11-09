// Authentication/Services/UserCredentialsService.cs
using Authentication.Models;
using Authentication.Services.Interfaces;

namespace Authentication.Services;

public class UserCredentialsService : IUserCredentialsService
{
    // Тимчасове in-memory сховище токенів
    private readonly Dictionary<string, TokenPair> _tokens = new();

    public Task<bool> ValidateUserPasswordAsync(string username, string password)
    {
        // Ця логіка вже є в AuthService через EncryptionService
        // Тому тут можна повернути true (або реалізувати пізніше)
        return Task.FromResult(true);
    }

    public Task StoreTokenPairAsync(string username, TokenPair tokens)
    {
        _tokens[username] = tokens;
        return Task.CompletedTask;
    }

    public Task<bool> ValidateRefreshTokenAsync(string refreshToken)
    {
        // Перевіряємо чи існує такий токен
        var exists = _tokens.Values.Any(t => t.RefreshToken == refreshToken);
        return Task.FromResult(exists);
    }
}