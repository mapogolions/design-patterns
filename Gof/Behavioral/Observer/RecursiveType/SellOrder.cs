namespace Gof.Behavioral.Observer.RecursiveType
{
    public class SellOrder : IObserver<CurrencyPair>
    {
        private readonly decimal _supportLevel;

        public bool CanSell { get; private set; }

        public SellOrder(decimal supportLevel) => _supportLevel = supportLevel;

        public void Update(CurrencyPair subject) => CanSell = subject.CurrentRate < _supportLevel;
    }
}
