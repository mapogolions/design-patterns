namespace Gof.Behavioral.Strategy;

public class PascalCaseNotation : INotation
{
    public string Convert(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        var parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return string.Join("", parts.Select(x => $"{char.ToUpper(x[0])}{x[1..]}"));
    }
}
