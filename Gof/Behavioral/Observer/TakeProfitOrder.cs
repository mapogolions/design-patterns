namespace Gof.Behavioral.Observer
{
    public class TakeProfitOrder : IObserver<CurrencyPair>
    {
        private readonly decimal _resistanceLevel;
        public bool CanBuy { get; private set; }

        public TakeProfitOrder(decimal resistanceLevel) => _resistanceLevel = resistanceLevel;

        public void Update(CurrencyPair subject) => CanBuy = subject.CurrentPrice > _resistanceLevel;
    }
}
