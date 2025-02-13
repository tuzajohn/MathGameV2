namespace MathGame.src.Domain.Common;

[Serializable]
public class MessageResponse(string? message, int code)
{
    public string? Message { get; private set; } = message;
    public int Code { get; private set; } = code;
}

[Serializable]
public class MessageResponse<TData>(string? message, int code, TData? data) : MessageResponse(message, code)
{
    public TData? Data { get; private set; } = data;
}
