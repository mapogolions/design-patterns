using System;

namespace Gof.Behavioral.Strategy
{
    public class HyphenNotation : INotation
    {
        public string Convert(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentException();
            }
            return identifier.Replace(oldChar: ' ', newChar: '-');
        }
    }
}
