namespace MathGame.src.Presentation.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void SignInClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(Constants.ToSignIn);
    }

    private async void SignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(Constants.ToSignUp);
    }
}
