namespace Gof.Behavioral.Strategy;

public class HyphenNotation : INotation
{
    public string Convert(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        return name.Replace(oldChar: ' ', newChar: '-');
    }
}
