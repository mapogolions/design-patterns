namespace Gof.Behavioral.Observer
{
    public class BuyOrder : IObserver<CurrencyPair>
    {
        private readonly decimal _resistanceLevel;
        public bool CanBuy { get; private set; }

        public BuyOrder(decimal resistanceLevel) => _resistanceLevel = resistanceLevel;

        public void Update(CurrencyPair subject) => CanBuy = subject.CurrentRate > _resistanceLevel;
    }
}
