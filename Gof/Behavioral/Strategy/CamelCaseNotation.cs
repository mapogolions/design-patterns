using System.Linq;
using System;

namespace Gof.Behavioral.Strategy
{
    public class CamelCaseNotation : INotation
    {
        public string Convert(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException();
            var parts = name.Split(' ');
            if (parts.Length is 1)
                return name;
            var pascalCase = new PascalCaseNotation();
            return pascalCase.Convert(string.Join(" ", parts.Skip(1)));
        }
    }
}
