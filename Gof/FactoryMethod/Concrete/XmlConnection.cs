using Gof.FactoryMethod.Abs;

namespace Gof.FactoryMethod.Concrete
{
    public class XmlConnection : IConnection
    {
        public IDataConnector Connector => new XmlFormatConnector();
    }
}
