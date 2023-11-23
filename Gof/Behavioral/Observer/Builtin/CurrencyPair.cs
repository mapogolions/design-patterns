namespace Gof.Behavioral.Observer.Builtin;

public class CurrencyPair : IObservable<CurrencyPair>, IDisposable
{
    private decimal _currentRate;
    private readonly List<IObserver<CurrencyPair>> _orders = new();

    public CurrencyPair(string name, decimal currentRate)
    {
        Name = name;
        CurrentRate = currentRate;
    }

    public string Name { get; }

    public decimal CurrentRate
    {
        get => _currentRate;
        set
        {
            _currentRate = value;
            foreach (var observer in _orders)
            {
                observer.OnNext(this);
            }
        }
    }

    public IDisposable Subscribe(IObserver<CurrencyPair> observer)
    {
        if (_orders.Contains(observer)) return NullDisposable.Singleton;
        _orders.Add(observer);
        observer.OnNext(this);
        return this;
    }

    public void Dispose()
    {
        _orders.Clear();
    }
}

internal class NullDisposable : IDisposable
{
    public static NullDisposable Singleton { get; } = new NullDisposable();

    private NullDisposable()
    {
    }

    public void Dispose()
    {
        //
    }
}
