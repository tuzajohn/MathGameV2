namespace MathGame.src.Presentation.ContentViews;

public partial class ParallaxHeaderView : ContentView
{
	public ParallaxHeaderView()
	{
		InitializeComponent();
	}

    public void UpdateParallax(double scrollY)
    {
        ParallaxImage.TranslationY = Math.Max(-scrollY * 0.5, -ParallaxImage.Height);
        double fadeFactor = 1 - (scrollY / 250.0);
        ParallaxImage.Opacity = Math.Max(fadeFactor, 0);
    }
}