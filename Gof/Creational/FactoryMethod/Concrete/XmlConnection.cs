using Gof.Creational.FactoryMethod.Abs;

namespace Gof.Creational.FactoryMethod.Concrete
{
    public class XmlConnection : IConnection
    {
        public IDataConnector Connector => new XmlFormatConnector();
    }
}
