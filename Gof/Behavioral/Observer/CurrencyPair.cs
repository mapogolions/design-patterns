using System.Collections.Generic;

namespace Gof.Behavioral.Observer
{
    public class CurrencyPair : ISubject
    {
        private string _name;
        private IList<IObserver> _orders = new List<IObserver>();
        public decimal CurrentPrice { get; private set; }

        public CurrencyPair(string name, decimal currentPrice)
        {
            _name = name;
            CurrentPrice = currentPrice;
        }

        public bool Attach(IObserver order)
        {
            if (_orders.Contains(order))
                return false;
            _orders.Add(order);
            return true;
        }

        public bool Detach(IObserver order)
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
