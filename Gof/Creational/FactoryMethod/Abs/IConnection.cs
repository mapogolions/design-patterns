namespace Gof.Creational.FactoryMethod.Abs
{
    public interface IConnection
    {
         IDataConnector Connector { get; }
    }
}
