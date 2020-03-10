using System.Collections.Generic;

namespace Gof.Structural.Decorator.Manipula
{
    public class TakeEnumerable<T> : BaseEnumerable<T>
    {
        private readonly IEnumerable<T> _origin;
        private readonly int _count;

        public TakeEnumerable(IEnumerable<T> origin, int count)
        {
            _origin = origin;
            _count = count;
        }

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
}
