namespace Gof.Structural.Bridge
{
    public class ContactsPage : WebPage
    {
        public ContactsPage(ITheme theme) : base(theme) {}
        public override string Render() => $"ContactsPage has {_theme.BackgroundColor} color";
    }
}
