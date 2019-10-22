namespace Gof.Behavioral.Observer
{
    public class StopLossOrder : IObserver<CurrencyPair>
    {
        private readonly decimal _supportLevel;
        public bool CanSell { get; private set; }

        public StopLossOrder(decimal supportLevel) => _supportLevel = supportLevel;

        public void Update(CurrencyPair subject) => CanSell = subject.CurrentPrice < _supportLevel;
    }
}
