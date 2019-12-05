using System.Collections;
using System.Collections.Generic;
namespace Gof.Structural.Decorator.Manipula
{
    public class AppendEnumerable<T> : IEnumerable<T>
    {
        private readonly T _item;
        private readonly IEnumerable<T> _origin;

        public AppendEnumerable(IEnumerable<T> origin, T item)
        {
            _origin = origin;
            _item = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _origin)
            {
                yield return item;
            }
            yield return _item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
