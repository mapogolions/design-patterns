namespace Gof.Behavioral.Observer.RecursiveType;

public interface IObserver<in T> where T : IObservable<T>
{
    void Update(T subject);
}
