namespace Gof.Behavioral.Observer
{
    public interface ISubject<T>
    {
         bool Attach(IObserver<T> observer);
         bool Detach(IObserver<T> observer);
         void Notify();
    }
}
