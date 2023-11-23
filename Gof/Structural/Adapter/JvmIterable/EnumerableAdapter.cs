
namespace Gof.Structural.Adapter.JvmIterable;

public class EnumerableAdapter<T>(IEnumerable<T> enumerable) : Iterable<T>
{
    private readonly IEnumerable<T> _enumerable = enumerable;

    public Iterator<T> Iterator() => new EnumeratorAdapter<T>(_enumerable.GetEnumerator());
}
