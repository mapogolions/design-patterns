using System.Collections;
using System.Collections.Generic;

namespace Gof.Structural.Adapter
{
    public class IterableAdapter<T> : IEnumerable<T>
    {
        private readonly Iterable<T> _iterable;

        public IterableAdapter(Iterable<T> iterable) => _iterable = iterable;

        public IEnumerator<T> GetEnumerator() => new IteratorAdapter<T>(_iterable.Iterator());

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
