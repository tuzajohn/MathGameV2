using MathGame.src.Presentation.ViewModels;
using System.Threading.Tasks;

namespace MathGame.src.Presentation.Pages;

public partial class PlaygroundPage : ContentPage
{
    readonly PlaygroundViewModel _viewModel;
	public PlaygroundPage(PlaygroundViewModel vm)
	{
		InitializeComponent();

        BindingContext = _viewModel = vm;
    }
    protected override async void OnAppearing()
    {

        await _viewModel.AddCommand.ExecuteAsync(new PlayFeatureRequest
        {

        });


        base.OnAppearing();
    }
}