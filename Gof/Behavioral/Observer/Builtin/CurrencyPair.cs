namespace Gof.Behavioral.Observer.Builtin
{

    public class CurrencyPair : ICurrencyPair
    {
        public CurrencyPair(string name, decimal currentRate)
        {
            Name = name;
            CurrentRate = currentRate;
        }

        public string Name { get; }

        public decimal CurrentRate { get; set; }
    }
}
