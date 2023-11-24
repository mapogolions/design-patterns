namespace Gof.Structural.Adapter.JvmIterable;

public interface Iterable<out T>
{
    Iterator<T> Iterator();
}
