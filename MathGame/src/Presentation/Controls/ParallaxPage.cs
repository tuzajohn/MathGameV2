using MathGame.src.Presentation.ContentViews;

namespace MathGame.src.Presentation.Controls;

public abstract class ParallaxPage : ContentPage
{
    protected ParallaxHeaderView ParallaxHeader;

    public static readonly BindableProperty TitleProperty = 
        BindableProperty.Create(nameof(Title),
            typeof(string), typeof(ParallaxPage),
            string.Empty);


    public ParallaxPage()
    {
        SetNavigationBarTransparent();
    }

    protected void AttachParallaxHeader(ParallaxHeaderView header)
    {
        ParallaxHeader = header;
    }

    protected void HandleScroll(double scrollY)
    {
        if (ParallaxHeader == null) return;

        // Apply parallax effect
        ParallaxHeader.UpdateParallax(scrollY);

        // Update Navigation Bar Transparency
        SetNavigationBarOpacity(scrollY);
    }

    private void SetNavigationBarTransparent()
    {
        Shell.SetTitleColor(this, Colors.Transparent);
    }

    private void SetNavigationBarOpacity(double opacity)
    {
        // Smooth transition from transparent to a solid color (e.g., white)
        Color backgroundColor = Color.FromRgba(0, 0, 0, 1 - opacity);
        Shell.SetTitleColor(this, backgroundColor);
    }
}
