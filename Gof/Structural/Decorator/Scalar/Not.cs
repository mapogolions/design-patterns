namespace Gof.Structural.Decorator.Scalar
{
    public class Not : IScalar<bool>
    {
        private readonly IScalar<bool> _origin;

        public Not(IScalar<bool> origin) => _origin = origin;

        public bool Value => !_origin.Value;
    }
}
