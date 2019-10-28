namespace Gof.Structural.Bridge
{
    public class AboutPage : WebPage
    {
        public AboutPage(ITheme theme) : base(theme) {}

        public override string Render() => $"About page has {_theme.BackgroundColor} color";
    }
}
