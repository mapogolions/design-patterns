namespace Gof.Structural.Adapter.JvmIterable;

public class EnumeratorAdapter<T>(IEnumerator<T> enumerator) : Iterator<T>
{
    private bool? _flag = null;
    private readonly IEnumerator<T> _enumerator = enumerator;

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
