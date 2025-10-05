namespace Authentication.Models.Exceptions;

public class InvalidCredentialsException : Exception
{
    public string Username { get; }

    public InvalidCredentialsException(string username)
        : base($"Invalid credentials for user '{username}'")
    {
        Username = username;
    }

    public InvalidCredentialsException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }
}