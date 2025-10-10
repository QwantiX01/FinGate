namespace Authentication.Models.Exceptions;

public class UserDoesNotExistsException : Exception
{
    public string Username { get; }

    public UserDoesNotExistsException(string username)
        : base($"User with username '{username}' does not exists")
    {
        Username = username;
    }

    public UserDoesNotExistsException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }
}