using System.Collections.Generic;

namespace Gof.Behavioral.Observer
{
    public class CurrencyPair : ISubject<CurrencyPair>
    {
        private string _name;
        private IList<IObserver<CurrencyPair>> _orders = new List<IObserver<CurrencyPair>>();
        private decimal _currentRate;
        public decimal CurrentRate {
            get
            {
                return _currentRate;
            }
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
            if (!_orders.Contains(order))
                return false;
            return _orders.Remove(order);
        }

        public void Notify()
        {
            foreach (var order in _orders)
                order.Update(this);
        }
    }
}
