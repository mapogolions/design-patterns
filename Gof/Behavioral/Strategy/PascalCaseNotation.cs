using System.Linq;
using System;
namespace Gof.Behavioral.Strategy
{
    public class PascalCaseNotation : INotation
    {
        public string Convert(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentException();
            var parts = identifier.Split(' ');
            return string.Join(string.Empty,
                parts.Select(it => it.First().ToString().ToUpper() + it.Substring(1)));
        }
    }
}
