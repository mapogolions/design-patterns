using System.Collections.Generic;

namespace Gof.Structural.Adapter.JvmIterable
{
    public class EnumeratorAdapter<T> : Iterator<T>
    {
        private readonly IEnumerator<T> _enumerator;

        public EnumeratorAdapter(IEnumerator<T> enumerator) => _enumerator = enumerator;

        public bool HasNext()
        {
            return _enumerator.MoveNext();
        }

        public T Next()
        {
            if (HasNext()) return _enumerator.Current;
            throw new NoSuchElementException();
        }
    }
}
