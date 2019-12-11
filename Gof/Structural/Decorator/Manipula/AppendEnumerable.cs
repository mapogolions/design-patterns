using System.Collections;
using System.Collections.Generic;
namespace Gof.Structural.Decorator.Manipula
{
    public class AppendEnumerable<T> : BaseEnumerable<T>
    {
        private readonly T _item;
        private readonly IEnumerable<T> _origin;

        public AppendEnumerable(IEnumerable<T> origin, T item)
        {
            _origin = origin;
            _item = item;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _origin)
            {
                yield return item;
            }
            yield return _item;
        }
    }
}
