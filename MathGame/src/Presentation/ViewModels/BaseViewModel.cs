namespace MathGame.src.Presentation.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    double _parallaxTranslation;

    public void UpdateParallax(double scrollY)
    {
        ParallaxTranslation = Math.Max(-100, -scrollY / 2);
    }
}
