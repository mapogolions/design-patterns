using System;
using System.Collections.Generic;

namespace Gof.Behavioral.Observer.Builtin
{
    public class ObservableCurrencyPair : ICurrencyPair, System.IObservable<ICurrencyPair>, IDisposable
    {
        private readonly ICurrencyPair _currencyPair;
        private readonly List<System.IObserver<ICurrencyPair>> _observers = new();

        public string Name => _currencyPair.Name;

        public decimal CurrentRate
        {
            get => _currencyPair.CurrentRate;
            set
            {
                _currencyPair.CurrentRate = value;
                foreach (var observer in _observers)
                {
                    observer.OnNext(_currencyPair);
                }
            }
        }

        public ObservableCurrencyPair(ICurrencyPair currencyPair)
        {
            _currencyPair = currencyPair;
        }

        public IDisposable Subscribe(System.IObserver<ICurrencyPair> observer)
        {
            _observers.Add(observer);
            observer.OnNext(_currencyPair);
            return this;
        }

        public void Dispose()
        {
            _observers.Clear();
        }
    }
}
