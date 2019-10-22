namespace Gof.Behavioral.Observer
{
    public class TakeProfitOrder : IObserver
    {
        private readonly decimal _resistanceLevel;
        private decimal _currentPrice = default;
        public bool CanBuy() => _currentPrice > _resistanceLevel;

        public TakeProfitOrder(decimal resistanceLevel) => _resistanceLevel = resistanceLevel;

        public void Update(ISubject subject)
        {
            if (subject is CurrencyPair currencyPair)
                _currentPrice = currencyPair.CurrentPrice;
        }
    }
}
