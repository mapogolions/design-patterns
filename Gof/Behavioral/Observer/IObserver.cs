namespace Gof.Behavioral.Observer
{
    public interface IObserver<in T>
    {
        void Update(T subject);
    }
}
