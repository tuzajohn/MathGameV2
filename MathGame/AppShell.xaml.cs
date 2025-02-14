using MathGame.src.Presentation.Pages.AuthenticationPages;

namespace MathGame
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


            Routing.RegisterRoute(Constants.ToPlayground, typeof(PlaygroundPage));
            Routing.RegisterRoute(Constants.ToSignIn, typeof(SignInPage));
            Routing.RegisterRoute(Constants.ToSignUp, typeof(SignUpPage));
        }
    }
}
