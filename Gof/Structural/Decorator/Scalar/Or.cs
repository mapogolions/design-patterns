using System.Linq;

namespace Gof.Structural.Decorator.Scalar
{
    public class Or : IScalar<bool>
    {
        private readonly IScalar<bool>[] _primitives;

        public Or(params IScalar<bool>[] primitives) => _primitives = primitives;

        public bool Value => _primitives.Any(it => it.Value);
    }
}
