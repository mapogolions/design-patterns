namespace Gof.Behavioral.Strategy
{
    public class CamelCaseNotation : INotation
    {
        private readonly PascalCaseNotation _pascalCaseNotation = new();

        public string Convert(string name)
        {
            var pascalCase = _pascalCaseNotation.Convert(name);
            return $"{char.ToLower(pascalCase[0])}{pascalCase.Substring(1)}";
        }
    }
}
