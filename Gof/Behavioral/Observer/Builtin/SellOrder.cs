namespace Gof.Behavioral.Observer.Builtin;

public class SellOrder : IObserver<CurrencyPair>
{
    private readonly decimal _level;

    public SellOrder(decimal level)
    {
        _level = level;
    }

    public bool CanSell { get; private set; }

    public void OnCompleted() => throw new NotImplementedException();

    public void OnError(Exception error) => throw new NotImplementedException();

    public void OnNext(CurrencyPair value) => CanSell = value.CurrentRate < _level;
}
