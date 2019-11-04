namespace Gof.Behavioral.Strategy
{
    public class Context
    {
        private readonly INotation _notation;

        public Context(INotation notation) => _notation = notation;

        public string Convert(string name) => _notation.Convert(name);
    }
}
