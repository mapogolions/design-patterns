namespace Gof.Structural.Bridge
{
    public class ContactsPage : WebPage
    {
        public ContactsPage(ITheme theme) : base(theme) {}
        public override string Render() => $"Contacts page has a {_theme.BackgroundColor} theme";
    }
}
