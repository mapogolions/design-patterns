namespace Gof.Structural.Decorator
{
    public class Not : Scalar<bool>
    {
        private readonly Scalar<bool> _origin;

        public Not(Scalar<bool> origin) => _origin = origin;

        public bool Value => !_origin.Value;
    }
}
