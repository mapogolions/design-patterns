namespace Gof.Structural.Decorator.Manipula;

public class IdentityEnumerable<T>(IEnumerable<T> origin) : BaseEnumerable<T>
{
    private readonly IEnumerable<T> _origin = origin;

    public override IEnumerator<T> GetEnumerator() => _origin.GetEnumerator();
}
