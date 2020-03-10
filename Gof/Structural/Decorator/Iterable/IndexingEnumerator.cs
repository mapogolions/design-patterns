using System.Collections;
using System.Collections.Generic;

namespace Gof.Structural.Decorator.Iterable
{
    internal class IndexingEnumerator<T> : IEnumerator<IndexedValue<T>>
    {
        private int _counter = -1;
        private readonly IEnumerator<T> _origin;

        public IndexingEnumerator(IEnumerator<T> origin) => _origin = origin;

        public IndexedValue<T> Current => new IndexedValue<T>(_counter, _origin.Current);

        object IEnumerator.Current => Current;

        public void Dispose() => _origin.Dispose();

        public bool MoveNext()
        {
            if (_origin.MoveNext())
            {
                _counter++;
                return true;
            }
            return false;
        }

        public void Reset() => _origin.Reset();
    }
}
