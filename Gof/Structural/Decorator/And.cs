using System.Linq;

namespace Gof.Structural.Decorator
{
    public class And : Scalar<bool>
    {
        private readonly Scalar<bool>[] _primitives;
        public And(params Scalar<bool>[] primitives) => _primitives = primitives;
        
        public bool Value => !_primitives.Any(it => it.Value is false);
    }
}
