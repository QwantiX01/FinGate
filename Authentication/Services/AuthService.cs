using Authentication.Contracts;
using Authentication.Data.Interfaces;
using Authentication.Models;
using Authentication.Models.Exceptions;
using Authentication.Services.Interfaces;

namespace Authentication.Services;

public class AuthService(
    IUserRepository userRepository,
    IEncryptionService encryptionService,
    ITokenService tokenService,
    IUserCredentialsService userCredentialsService,
    ILogger<AuthService> logger)
    : IAuthService
{
    // Raises:
    // - UserAlreadyExistsException
    // - FailedToCreateUserException
    public async Task<TokenPair> RegisterAsync(UserRegisterContract registerContract)
    {
        logger.LogInformation("Attempting to register user: {Username}", registerContract.Username);

        // Is a user exists in the credentials' database?
        var userCredentials = await userRepository.GetByUsernameAsync(registerContract.Username);
        if (userCredentials != null)
        {
            logger.LogWarning("Registration failed: User already exists: {Username}", registerContract.Username);
            throw new UserAlreadyExistsException(registerContract.Username);
        }

        var userPasswordHash = encryptionService.EncryptString(registerContract.Password);
        var newUser = new User(registerContract.Username, userPasswordHash, registerContract.Email);

        await userRepository.CreateAsync(newUser);
        logger.LogInformation("User registered successfully: {Username}", registerContract.Username);

        return await LoginAsync(new UserLoginContract(registerContract.Username, registerContract.Password));
    }

    public async Task<TokenPair> LoginAsync(UserLoginContract loginContract)
    {
        logger.LogInformation("Login attempt for user: {Username}", loginContract.Username);

        var userCredentials = await userRepository.GetByUsernameAsync(loginContract.Username);
        if (userCredentials == null)
        {
            logger.LogWarning("Login failed: User not found: {Username}", loginContract.Username);
            throw new InvalidCredentialsException(loginContract.Username);
        }

        var isPasswordValid =
            await userCredentialsService.ValidateUserPasswordAsync(loginContract.Username, loginContract.Password);
        if (!isPasswordValid)
        {
            logger.LogInformation("Login failed: Password doesn't match: {Username}", loginContract.Username);
            throw new InvalidCredentialsException(loginContract.Username);
        }

        var accessToken = tokenService.GenerateToken(userCredentials);
        var refreshToken = tokenService.GenerateRefreshToken(userCredentials);
        var tokenPair = new TokenPair(accessToken, refreshToken);

        await userCredentialsService.StoreRefreshTokenAsync(userCredentials.Username, refreshToken);
        logger.LogInformation("User logged in successfully: {Username}", loginContract.Username);
        return tokenPair;
    }

    public async Task<TokenPair> RefreshTokenAsync(TokenRefreshContract refreshContract)
    {
        logger.LogInformation("Token refresh attempt for token: {Token}", refreshContract.RefreshToken);

        if (string.IsNullOrWhiteSpace(refreshContract.RefreshToken))
        {
            logger.LogWarning("Token refresh failed: Empty refresh token provided");
            throw new InvalidTokenException("Refresh token cannot be empty");
        }

        var username = tokenService.GetUsernameFromToken(refreshContract.RefreshToken);
        if (username == null)
        {
            logger.LogWarning("Token refresh failed: Username not found in token");
            throw new InvalidTokenException("Invalid token: username not found");
        }

        var userCredentials = await userRepository.GetByUsernameAsync(username);
        if (userCredentials == null)
        {
            logger.LogWarning("Token refresh failed: User not found: {Username}", username);
            throw new InvalidCredentialsException(username);
        }

        var isValid = await userCredentialsService.ValidateRefreshTokenAsync(username, refreshContract.RefreshToken);
        if (!isValid)
        {
            logger.LogWarning("Token refresh failed: Invalid refresh token");
            throw new InvalidTokenException("Invalid refresh token");
        }

        var accessToken = tokenService.GenerateToken(userCredentials);
        var refreshToken = tokenService.GenerateRefreshToken(userCredentials);
        var tokenPair = new TokenPair(accessToken, refreshToken);

        await userCredentialsService.StoreRefreshTokenAsync(userCredentials.Username, refreshToken);
        logger.LogInformation("Token refresh successful for user: {Username}", userCredentials.Username);
        return tokenPair;
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }
}