using MathGame.src.Application.Features.SignInFeature;

namespace MathGame.src.Presentation.ViewModels.AuthenticationVm;

public partial class SignInViewModel : BaseViewModel
{
    readonly IMediator _mediator;

    public SignInViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty]
    string email;

    [ObservableProperty]
    string password;

    [RelayCommand]
    async Task ToSignUp()
    {
        await Shell.Current.GoToAsync("../" + Constants.ToSignUp);
    }

    [RelayCommand]
    async Task SignIn()
    {
        var response = await _mediator.Send(new SignInFeatureRequest
        {
            Email = Email,
            Password = Password
        });

        IsBusy = true;

        if (response.ShowMessageAndStopExecution())
        {
            IsBusy = false;
            return;
        }
    }
}
