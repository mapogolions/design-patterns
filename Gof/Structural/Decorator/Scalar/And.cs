using System.Linq;

namespace Gof.Structural.Decorator.Scalar
{
    public class And : IScalar<bool>
    {
        private readonly IScalar<bool>[] _primitives;
        public And(params IScalar<bool>[] primitives) => _primitives = primitives;

        public bool Value => _primitives.All(it => it.Value);
    }
}
