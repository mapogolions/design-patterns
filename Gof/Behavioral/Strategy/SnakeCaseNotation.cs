using System;
namespace Gof.Behavioral.Strategy
{
    public class SnakeCaseNotation : INotation
    {
        public string Convert(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentException();
            return identifier.Replace(oldChar: ' ', newChar: '_');
        }
    }
}
