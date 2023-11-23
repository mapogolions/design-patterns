namespace Gof.Behavioral.Observer.Builtin;

public class BuyOrder(decimal level) : IObserver<CurrencyPair>
{
    private readonly decimal _level = level;

    public bool CanBuy { get; private set; }

    public void OnCompleted() => throw new NotImplementedException();
    public void OnError(Exception error) => throw new NotImplementedException();
    public void OnNext(CurrencyPair value) => CanBuy = value.CurrentRate > _level;
}
