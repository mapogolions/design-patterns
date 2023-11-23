namespace Gof.Structural.Bridge;

public class AboutPage(ITheme theme) : WebPage(theme)
{
    public override string Render() => $"About page has a {_theme.BackgroundColor} theme";
}
