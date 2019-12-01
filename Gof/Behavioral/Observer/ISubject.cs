namespace Gof.Behavioral.Observer
{
    public interface ISubject<out T>
    {
         bool Attach(IObserver<T> observer);
         bool Detach(IObserver<T> observer);
         void Notify();
    }
}
