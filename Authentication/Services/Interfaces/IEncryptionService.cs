namespace Authentication.Services.Interfaces;

/// <summary>
/// Service for encrypting and decrypting sensitive data.
/// </summary>
public interface IEncryptionService
{
    /// <summary>
    /// Encrypts a string using the specified encryption key or the default key from appsettings.
    /// </summary>
    /// <param name="password">The plaintext string to encrypt.</param>
    /// <param name="key">The encryption key. If not provided, the default key from appsettings will be used.</param>
    /// <returns>The encrypted string.</returns>
    string EncryptString(string password, string? key = null);
    

}