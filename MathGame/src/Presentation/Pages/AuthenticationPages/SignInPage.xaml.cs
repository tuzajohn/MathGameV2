using MathGame.src.Presentation.ViewModels.AuthenticationVm;

namespace MathGame.src.Presentation.Pages.AuthenticationPages;

public partial class SignInPage : ContentPage
{
	readonly SignInViewModel _viewModel;
	public SignInPage(SignInViewModel vm)
	{
		InitializeComponent();


		BindingContext = _viewModel = vm;
	}
}