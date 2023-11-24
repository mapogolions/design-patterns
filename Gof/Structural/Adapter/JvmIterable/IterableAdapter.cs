using System.Collections;

namespace Gof.Structural.Adapter.JvmIterable;

public class IterableAdapter<T> : IEnumerable<T>
{
    private readonly Iterable<T> _iterable;

    public IterableAdapter(Iterable<T> iterable)
    {
        _iterable = iterable;
    }

    public IEnumerator<T> GetEnumerator() => new IteratorAdapter<T>(_iterable.Iterator());

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
