namespace Gof.Behavioral.Observer.RecursiveType;

public class SellOrder(decimal supportLevel) : IObserver<CurrencyPair>
{
    private readonly decimal _supportLevel = supportLevel;

    public bool CanSell { get; private set; }

    public void Update(CurrencyPair subject) => CanSell = subject.CurrentRate < _supportLevel;
}
