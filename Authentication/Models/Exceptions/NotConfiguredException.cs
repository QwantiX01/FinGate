namespace Authentication.Models.Exceptions;

public class NotConfiguredException : Exception
{
    public NotConfiguredException(string configurationKey)
        : base($"Key '{configurationKey} 'is not configured")
    {
    }

    public NotConfiguredException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }
}