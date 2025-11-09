using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.Models;
using Authentication.Models.Exceptions;
using Authentication.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly JwtSecurityTokenHandler _tokenHandler = new();

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        var secretKey = _configuration["Jwt:SecretKey"] 
            ?? throw new NotConfiguredException("Jwt:SecretKey");
        
        // 🆕 Читаємо expiration з конфігу
        var expirationMinutes = int.Parse(_configuration["Jwt:AccessTokenExpirationMinutes"] ?? "15");
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username),
            new(JwtRegisteredClaimNames.Sub, user.Username),
        };

        if (!string.IsNullOrEmpty(user.Email))
        {
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
        }

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes), // 🆕 З конфігу
            signingCredentials: credentials
        );

        return _tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken(User user)
    {
        var secretKey = _configuration["Jwt:SecretKey"] 
            ?? throw new NotConfiguredException("Jwt:SecretKey");
        
        // 🆕 Читаємо expiration з конфігу
        var expirationDays = int.Parse(_configuration["Jwt:RefreshTokenExpirationDays"] ?? "7");
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim("token_type", "refresh")
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(expirationDays), // 🆕 З конфігу
            signingCredentials: credentials
        );

        return _tokenHandler.WriteToken(token);
    }

    public string? GetUsernameFromToken(string token)
    {
        try
        {
            var jwtToken = _tokenHandler.ReadJwtToken(token);
            return jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        }
        catch
        {
            return null;
        }
    }
}