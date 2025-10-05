namespace Authentication.Models.Exceptions;

public class InvalidTokenException : Exception
{
    public string Token { get; }

    public InvalidTokenException(string token)
        : base($"Invalid token: '{token}'")
    {
        Token = token;
    }

    public InvalidTokenException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }
}