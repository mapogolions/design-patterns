using System.Collections;
using System.Collections.Generic;

namespace Gof.Structural.Decorator.Manipula
{
    public class IdentityEnumerator<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _origin;

        public IdentityEnumerator(IEnumerable<T> origin) => _origin = origin;

        public IEnumerator<T> GetEnumerator()
        {
            return _origin.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
