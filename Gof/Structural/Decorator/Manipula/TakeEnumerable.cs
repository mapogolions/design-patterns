namespace Gof.Structural.Decorator.Manipula;

public class TakeEnumerable<T>(IEnumerable<T> origin, int count) : BaseEnumerable<T>
{
    private readonly IEnumerable<T> _origin = origin;
    private readonly int _count = count;

    public override IEnumerator<T> GetEnumerator()
    {
        var index = 0;
        foreach (var item in _origin)
        {
            if (++index > _count) break;
            yield return item;
        }
    }
}
