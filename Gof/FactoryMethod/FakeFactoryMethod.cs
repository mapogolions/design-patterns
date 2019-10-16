using Gof.FactoryMethod.Abs;

namespace Gof.FactoryMethod
{
    public class FakeFactoryMethod
    {
        public IConnection Connection { get; set; }
        public string ParseData() => Connection.Connector.ParseData();
    }
}
