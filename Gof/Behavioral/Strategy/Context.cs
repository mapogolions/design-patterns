namespace Gof.Behavioral.Strategy
{
    public class Context
    {
        private readonly INotation _notation;

        public Context(INotation notation) => _notation = notation;

        public string Convert(string identifier) => _notation.Convert(identifier);
    }
}
