using System.Collections.Generic;

namespace Gof.Structural.Adapter.JvmIterable
{
    public class EnumerableAdapter<T> : Iterable<T>
    {
        private readonly IEnumerable<T> _enumerable;

        public EnumerableAdapter(IEnumerable<T> enumerable) => _enumerable = enumerable;

        public Iterator<T> Iterator() => new EnumeratorAdapter<T>(_enumerable.GetEnumerator());
    }
}
