using System.Collections.Generic;

namespace Gof.Structural.Decorator.Iterable
{
    public static class IEnumeratorExtensions
    {
        public static IEnumerator<IndexedValue<T>> WithIndex<T>(this IEnumerator<T> enumerator) =>
            new IndexingEnumerator<T>(enumerator);
    }
}
