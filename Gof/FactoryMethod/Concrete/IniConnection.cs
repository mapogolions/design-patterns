using Gof.FactoryMethod.Abs;

namespace Gof.FactoryMethod.Concrete
{
    public class IniConnection : IConnection
    {
        public IDataConnector Connector => new IniFormatConnector();
    }
}
