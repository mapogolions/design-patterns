namespace Gof.Behavioral.Observer.RecursiveType;

public interface IObservable<out T> where T : IObservable<T>
{
    bool Attach(IObserver<T> observer);
    bool Detach(IObserver<T> observer);
    void Notify();
}
