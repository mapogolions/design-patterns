namespace Gof.Structural.Decorator.Manipula;

public class SkipLastEnumerable<T>(IEnumerable<T> origin, int count) : BaseEnumerable<T>
{
    private readonly IEnumerable<T> _origin = origin;
    private readonly int _count = count;

    public override IEnumerator<T> GetEnumerator()
    {
        if (_count <= 0)
        {
            foreach (var item in _origin)
                yield return item;
        }
        else
        {
            var queue = new Queue<T>();
            foreach (var item in _origin)
            {
                if (queue.Count == _count) yield return queue.Dequeue();
                queue.Enqueue(item);
            }
        }
    }
}
