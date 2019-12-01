namespace Gof.Structural.Decorator.Scalar
{
    public interface IScalar<out T>
    {
        T Value { get; }
    }
}
