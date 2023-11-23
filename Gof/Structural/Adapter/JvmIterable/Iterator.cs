namespace Gof.Structural.Adapter.JvmIterable;

public interface Iterator<T>
{
    bool HasNext();
    T Next();
}
