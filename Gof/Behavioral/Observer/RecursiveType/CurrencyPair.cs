
namespace Gof.Behavioral.Observer.RecursiveType;

public class CurrencyPair : IObservable<CurrencyPair>
{
    private readonly List<IObserver<CurrencyPair>> _orders = new();
    private decimal _currentRate;

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
            Notify();
        }
    }

    public bool Attach(IObserver<CurrencyPair> order)
    {
        if (_orders.Contains(order)) return false;
        _orders.Add(order);
        order.Update(this);
        return true;
    }

    public bool Detach(IObserver<CurrencyPair> order)
    {
        return _orders.Remove(order);
    }

    public void Notify()
    {
        foreach (var order in _orders)
        {
            order.Update(this);
        }
    }
}
