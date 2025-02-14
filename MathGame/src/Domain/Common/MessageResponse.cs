using CommunityToolkit.Maui.Alerts;
using MathGame.src.Infrastructure.Common.Helpers;

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



public static class MessageResponseExt
{
    public static void ShowMessage(this MessageResponse messageResponse)
    {
        MainThreadHelper.ExecuteOnMainThread(async () =>
        {
            await Shell.Current.DisplaySnackbar(messageResponse.Message!);
        });
    }

    public static bool ShowMessageAndStopExecution(this MessageResponse messageResponse)
    {
        MainThreadHelper.ExecuteOnMainThread(async () =>
        {
            await Shell.Current.DisplaySnackbar(messageResponse.Message!);
        });

        return messageResponse.Code != 0;
    }
}