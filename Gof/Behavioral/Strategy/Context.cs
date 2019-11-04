using System.Collections.Generic;

namespace Gof.Behavioral.Strategy
{
    public class Context
    {
        private readonly IEnumerable<string> _names = new List<string>();
        private readonly INotation _notation;

        public Context(IEnumerable<string> names, INotation notation)
        {
            _notation = notation;
            _names = names;
        }
    }
}
