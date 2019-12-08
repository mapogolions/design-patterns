using System.Collections.Generic;

namespace Gof.Behavioral.Observer
{
    public class CurrencyPair : IObservable<CurrencyPair>
    {
        private readonly string _name;
        private readonly IList<IObserver<CurrencyPair>> _orders = new List<IObserver<CurrencyPair>>();
        private decimal _currentRate;
        public decimal CurrentRate {
            get => _currentRate;
            set
            {
                _currentRate = value;
                Notify();
            }
        }

        public CurrencyPair(string name, decimal currentRate)
        {
            _name = name;
            CurrentRate = currentRate;
        }

        public bool Attach(IObserver<CurrencyPair> order)
        {
            if (_orders.Contains(order))
                return false;
            _orders.Add(order);
            return true;
        }

        public bool Detach(IObserver<CurrencyPair> order)
        {
            return _orders.Remove(order);
        }

        public void Notify()
        {
            foreach (var order in _orders)
                order.Update(this);
        }
    }
}
