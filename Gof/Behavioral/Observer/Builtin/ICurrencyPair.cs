namespace Gof.Behavioral.Observer.Builtin
{
    public interface ICurrencyPair
    {
        string Name { get; }
        decimal CurrentRate { get; set; }
    }
}
