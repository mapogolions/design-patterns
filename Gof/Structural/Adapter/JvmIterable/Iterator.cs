namespace Gof.Structural.Adapter.JvmIterable;

public interface Iterator<out T>
{
    bool HasNext();
    T Next();
}
