namespace Gof.Structural.Decorator.Manipula;

public class AppendEnumerable<T>(IEnumerable<T> origin, T item) : BaseEnumerable<T>
{
    private readonly T _item = item;
    private readonly IEnumerable<T> _origin = origin;

    public override IEnumerator<T> GetEnumerator()
    {
        foreach (var item in _origin)
        {
            yield return item;
        }
        yield return _item;
    }
}
