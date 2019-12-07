namespace Gof.Structural.Adapter
{
    public interface Iterator<T>
    {
        bool HasNext();
        T Next();
    }
}
