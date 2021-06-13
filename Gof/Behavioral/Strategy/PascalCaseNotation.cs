using System;
using System.Linq;

namespace Gof.Behavioral.Strategy
{
    public class PascalCaseNotation : INotation
    {
        public string Convert(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentException();
            }
            var parts = identifier.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return string.Join("", parts.Select(x => $"{char.ToUpper(x[0])}{x.Substring(1)}"));
        }
    }
}
