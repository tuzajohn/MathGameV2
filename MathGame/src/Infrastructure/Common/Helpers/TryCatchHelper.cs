namespace MathGame.src.Infrastructure.Common.Helpers;

public static class TryCatchHelper
{
    public static void Try(Action action)
    {
        try
        {
            action();
        }
        catch (GenericException ex)
        {
            MainThreadHelper.ExecuteOnMainThread(async () =>
            {
                await Shell.Current.DisplayAlert("", ex.ExtractMessage(), "OK");
            });
        }
        catch (Exception ex)
        {
            MainThreadHelper.ExecuteOnMainThread(async () =>
            {
                await Shell.Current.DisplayAlert("", ex.ExtractMessage(), "OK");
            });

        }
        finally
        {

        }
    }

    private static string ExtractMessage(this Exception ex)
    {
        if (ex == null) return string.Empty;

        var exceptionMessages = new List<string>();
        Exception currentException = ex;

        while (currentException != null)
        {
            if (!string.IsNullOrWhiteSpace(currentException.Message))
                exceptionMessages.Add(currentException.Message);

            if (currentException.InnerException == null)
                break;

            currentException = currentException.InnerException;
        }

        return exceptionMessages.LastOrDefault() ?? ex.Message;
    }
}
