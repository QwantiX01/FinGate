namespace Authentication.Services.Interfaces;

/// <summary>
/// Service for encrypting and decrypting sensitive data.
/// </summary>
public interface IEncryptionService
{
    /// <summary>
    /// Encrypts a string using the specified encryption key.
    /// </summary>
    /// <param name="password">The plaintext string to encrypt.</param>
    /// <param name="key">The encryption key.</param>
    /// <returns>The encrypted string.</returns>
    string EncryptString(string password, string key);
    
    /// <summary>
    /// Decrypts an encrypted string using the specified decryption key.
    /// </summary>
    /// <param name="password">The encrypted string to decrypt.</param>
    /// <param name="key">The decryption key.</param>
    /// <returns>The decrypted plaintext string.</returns>
    string DecryptString(string password, string key);
}