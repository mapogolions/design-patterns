namespace Gof.Behavioral.Observer
{
    public class StopLossOrder
    {
        private readonly decimal _supportLevel;
        private decimal _currentPrice = default;

        public bool CanSell() => _supportLevel < _currentPrice;

        public StopLossOrder(decimal supportLevel) => _supportLevel = supportLevel;

        public void Update(ISubject subject)
        {
            if (subject is CurrencyPair currencyPair)
                _currentPrice = currencyPair.CurrentPrice;
        }
    }
}
