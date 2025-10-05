namespace Authentication.Models.Exceptions;

public class FailedToCreateUserException : Exception
{
    public string Username { get; }

    public FailedToCreateUserException(string username)
        : base($"Failed to create user with username '{username}'")
    {
        Username = username;
    }

    public FailedToCreateUserException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }
}