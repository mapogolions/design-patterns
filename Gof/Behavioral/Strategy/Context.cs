namespace Gof.Behavioral.Strategy;

public class Context(INotation notation)
{
    private readonly INotation _notation = notation;

    public string Convert(string name) => _notation.Convert(name);
}
