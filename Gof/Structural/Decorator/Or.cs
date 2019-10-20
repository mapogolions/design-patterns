using System.Linq;

namespace Gof.Structural.Decorator
{
    public class Or : Scalar<bool>
    {
        private readonly Scalar<bool>[] _primitives;

        public Or(params Scalar<bool>[] primitives) => _primitives = primitives;

        public bool Value => _primitives.Any(it => it.Value);
    }
}
