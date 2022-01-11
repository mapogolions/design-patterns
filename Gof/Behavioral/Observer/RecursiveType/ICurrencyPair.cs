namespace Gof.Behavioral.Observer.RecursiveType
{
    public interface ICurrencyPair
    {
        string Name { get; }
        decimal CurrentRate { get; set; }
    }
}
