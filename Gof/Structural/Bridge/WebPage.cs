namespace Gof.Structural.Bridge
{
    public abstract class WebPage
    {
        protected readonly ITheme _theme;

        public WebPage(ITheme theme) => _theme = theme;

        public abstract string Render();
    }
}
