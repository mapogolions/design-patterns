using System;

namespace Gof.Behavioral.Observer.Builtin
{
    public class BuyOrder : System.IObserver<ICurrencyPair>
    {
        private readonly decimal _level;

        public BuyOrder(decimal level)
        {
            _level = level;
        }

        public bool CanBuy { get; private set; }

        public void OnCompleted() => throw new NotImplementedException();
        public void OnError(Exception error) => throw new NotImplementedException();
        public void OnNext(ICurrencyPair value) => CanBuy = value.CurrentRate > _level;
    }
}
