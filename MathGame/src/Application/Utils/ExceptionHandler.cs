using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace MathGame.src.Application.Utils;

public class ExceptionHandler
{
    public ExceptionHandler()
    {

    }

    public void Initialize(IServiceProvider serviceProvider)
    {
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Debug.WriteLine($"Error: {e.ExceptionObject}");

        Environment.Exit(0);
    }
}
