namespace Gof.Behavioral.Strategy
{
    public class CamelCaseNotation : INotation
    {
        private readonly PascalCaseNotation _pascalCaseNotation = new();

        public string Convert(string identifier)
        {
            var pascalCaseIdentifier = _pascalCaseNotation.Convert(identifier);
            return $"{char.ToLower(pascalCaseIdentifier[0])}{pascalCaseIdentifier.Substring(1)}";
        }
    }
}
