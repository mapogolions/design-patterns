namespace Gof.Behavioral.Observer
{
    public interface IObserver<T>
    {
        void Update(T subject);
    }
}
