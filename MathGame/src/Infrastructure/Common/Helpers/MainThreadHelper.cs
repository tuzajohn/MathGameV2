using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.src.Infrastructure.Common.Helpers;

public class MainThreadHelper
{
    public static void ExecuteOnMainThread(Action action)
    {
        if (MainThread.IsMainThread)
        {
            action();
        }
        else
        {
            MainThread.BeginInvokeOnMainThread(action);
        }
    }
}
