using System.Collections;

namespace Gof.Structural.Decorator.Manipula;

public abstract class BaseEnumerable<T> : IEnumerable<T>
{
    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
