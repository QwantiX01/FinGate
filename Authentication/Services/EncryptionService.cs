using System.Security.Cryptography;
using System.Text;
using Authentication.Models.Exceptions;
using Authentication.Services.Interfaces;


namespace Authentication.Services;

public class EncryptionService(IConfiguration configuration) : IEncryptionService
{
    private readonly string _iv = configuration["Encryption:Iv"] ?? throw new NotConfiguredException("Encryption:Iv");
    private readonly string _secretKey = configuration["Encryption:SecretKey"] ?? throw new NotConfiguredException("Encryption:SecretKey");

    public string EncryptString(string password, string? key = null)
    {
        key ??= _secretKey;
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = Encoding.UTF8.GetBytes(_iv);

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream();
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs))
            sw.Write(password);

        return Convert.ToBase64String(ms.ToArray());
    }

    public string DecryptString(string password, string? key = null)
    {
        key ??= _secretKey;
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = Encoding.UTF8.GetBytes(_iv);

        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using var ms = new MemoryStream(Convert.FromBase64String(password));
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }
}