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
            return string.Join(string.Empty,
                parts.Select(it => it.First().ToString().ToUpper() + it.Substring(1)));
        }
    }
}
