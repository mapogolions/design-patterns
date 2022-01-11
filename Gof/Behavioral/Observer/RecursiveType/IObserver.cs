namespace Gof.Behavioral.Observer.RecursiveType
{
    public interface IObserver<T> where T : IObservable<T>
    {
        void Update(T subject);
    }
}
