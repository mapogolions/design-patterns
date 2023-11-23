using System.Collections;

namespace Gof.Structural.Adapter.JvmIterable;

public class IteratorAdapter<T>(Iterator<T> iterator) : IEnumerator<T>
{
    private readonly Iterator<T> _iterator = iterator;
    private T _value = default;

    public T Current => _value;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (!_iterator.HasNext()) return false;
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
