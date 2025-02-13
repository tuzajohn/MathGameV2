using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace MathGame
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
        }

        private void AndroidEnvironment_UnhandledExceptionRaiser(object? sender, RaiseThrowableEventArgs e)
        {

            // Handle the exception
            e.Handled = true;
        }
    }
    
}
