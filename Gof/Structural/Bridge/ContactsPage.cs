namespace Gof.Structural.Bridge;

public class ContactsPage(ITheme theme) : WebPage(theme)
{
    public override string Render() => $"Contacts page has a {_theme.BackgroundColor} theme";
}
