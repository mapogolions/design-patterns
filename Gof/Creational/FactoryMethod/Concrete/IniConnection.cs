using Gof.Creational.FactoryMethod.Abs;

namespace Gof.Creational.FactoryMethod.Concrete
{
    public class IniConnection : IConnection
    {
        public IDataConnector Connector => new IniFormatConnector();
    }
}
