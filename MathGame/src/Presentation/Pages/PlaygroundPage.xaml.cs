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

        SetNavigationBarTransparent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private void OnScrollViewScrolled(object sender, ScrolledEventArgs e)
    {
        double scrollY = e.ScrollY;

        ParallaxImage.TranslationY = scrollY * 0.5; 
        double fadeFactor = 1 - (scrollY / 300);
        ParallaxImage.Opacity = Math.Max(fadeFactor, 0);
        SetNavigationBarOpacity(fadeFactor);
    }
    private void SetNavigationBarTransparent()
    {
        Shell.SetTitleColor(this, Colors.Transparent);
    }

    private void SetNavigationBarOpacity(double opacity)
    {
        Color backgroundColor = Color.FromRgba(0, 0, 0, 1 - opacity);
        Shell.SetTitleColor(this, backgroundColor);
    }
}