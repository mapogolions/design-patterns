using System.Collections;
using System.Collections.Generic;

namespace Gof.Structural.Decorator.Manipula
{
    public class SkipLastEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _origin;
        private readonly int _count;

        public SkipLastEnumerable(IEnumerable<T> origin, int count)
        {
            _origin = origin;
            _count = count;
        }

        public IEnumerator<T> GetEnumerator()
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
