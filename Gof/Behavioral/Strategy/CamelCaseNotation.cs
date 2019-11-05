using System.Linq;
using System;

namespace Gof.Behavioral.Strategy
{
    public class CamelCaseNotation : INotation
    {
        public string Convert(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentException();
            var parts = identifier.Split(' ');
            if (parts.Length is 1)
                return identifier;
            var pascalCase = new PascalCaseNotation();
            return $"{parts[0]}{pascalCase.Convert(string.Join(" ", parts.Skip(1)))}";
        }
    }
}
