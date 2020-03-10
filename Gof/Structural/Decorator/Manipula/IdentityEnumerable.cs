using System.Collections.Generic;

namespace Gof.Structural.Decorator.Manipula
{
    public class IdentityEnumerable<T> : BaseEnumerable<T>
    {
        private readonly IEnumerable<T> _origin;

        public IdentityEnumerable(IEnumerable<T> origin) => _origin = origin;

        public override IEnumerator<T> GetEnumerator() => _origin.GetEnumerator();
    }
}
