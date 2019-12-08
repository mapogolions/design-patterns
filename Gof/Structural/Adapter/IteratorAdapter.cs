using System;
using System.Collections;
using System.Collections.Generic;

namespace Gof.Structural.Adapter
{
    public class IteratorAdapter<T> : IEnumerator<T>
    {
        private readonly Iterator<T> _iterator;
        private T _value = default(T);

        public IteratorAdapter(Iterator<T> iterator) => _iterator = iterator;

        public T Current => _value;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (!_iterator.HasNext())
                return false;
            _value = _iterator.Next();
            return true;
        }

        public void Reset()
        {
            //
        }

        public void Dispose()
        {
            //
        }
    }
}
