namespace Gof.Behavioral.Observer.RecursiveType;

public class BuyOrder : IObserver<CurrencyPair>
{
    private readonly decimal _resistanceLevel;

    public BuyOrder(decimal resistanceLevel)
    {
        _resistanceLevel = resistanceLevel;
    }

    public bool CanBuy { get; private set; }

    public void Update(CurrencyPair subject) => CanBuy = subject.CurrentRate > _resistanceLevel;
}
