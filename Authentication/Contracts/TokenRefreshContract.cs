namespace Authentication.Contracts;

public record TokenRefreshContract(string RefreshToken, string AccessToken);