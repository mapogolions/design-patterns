namespace Gof.Behavioral.Observer
{
    public interface IObserver<T> where T : IObservable<T>
    {
        void Update(T subject);
    }
}
