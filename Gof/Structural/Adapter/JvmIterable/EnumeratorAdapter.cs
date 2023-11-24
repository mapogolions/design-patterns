namespace Gof.Structural.Adapter.JvmIterable;

public class EnumeratorAdapter<T> : Iterator<T>
{
    private bool? _flag = null;
    private readonly IEnumerator<T> _enumerator;

    public EnumeratorAdapter(IEnumerator<T> enumerator)
    {
        _enumerator = enumerator;
    }

    public bool HasNext()
    {
        if (_flag is null)
        {
            _flag = _enumerator.MoveNext();
        }
        return _flag.Value;
    }

    public T Next()
    {
        if (HasNext())
        {
            _flag = null;
            return _enumerator.Current;
        }
        throw new NoSuchElementException();
    }
}
