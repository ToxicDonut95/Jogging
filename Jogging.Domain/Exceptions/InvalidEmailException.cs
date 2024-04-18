using System.Runtime.Serialization;

namespace Jogging.Domain.Exceptions;

public class InvalidEmailException : Exception
{
    public InvalidEmailException()
    {
    }

    protected InvalidEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public InvalidEmailException(string? message) : base(message)
    {
    }

    public InvalidEmailException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}