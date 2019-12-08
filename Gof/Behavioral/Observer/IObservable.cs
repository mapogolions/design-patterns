namespace Gof.Behavioral.Observer
{
    public interface IObservable<T> where T : IObservable<T>
    {
         bool Attach(IObserver<T> observer);
         bool Detach(IObserver<T> observer);
         void Notify();
    }
}
