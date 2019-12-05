using System.Collections;
using System.Collections.Generic;

namespace Gof.Structural.Decorator.Manipula
{
    public class TakeEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _origin;
        private readonly int _count;

        public TakeEnumerable(IEnumerable<T> origin, int count)
        {
            _origin = origin;
            _count = count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var index = 0;
            foreach (var item in _origin)
            {
                if (++index > _count) break;
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}