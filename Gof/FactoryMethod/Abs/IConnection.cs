namespace Gof.FactoryMethod.Abs
{
    public interface IConnection
    {
         IDataConnector Connector { get; }
    }
}
