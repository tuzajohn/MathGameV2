using MathGame.src.Domain.Common;

namespace MathGame.src.Infrastructure.Common.CustomExceptions;

public class NotAddedException : Exception
{
    public NotAddedException(MessageResponse response)
        : base(response.Message)
    {

    }

    public NotAddedException(string message, Exception innerException)
        : base(message, innerException) 
    {
    }

    public NotAddedException() { }
}
