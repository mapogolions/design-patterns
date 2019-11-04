using System;
namespace Gof.Behavioral.Strategy
{
    public class HyphenNotation : INotation
    {
        public string Convert(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException();
            return name.Replace(oldChar: ' ', newChar: '-');
        }
    }
}
