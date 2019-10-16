using Gof.Creational.FactoryMethod.Abs;

namespace Gof.Creational.FactoryMethod
{
    public class FakeClient
    {
        public IConnection Connection { get; set; }
        public string ParseData() => Connection.Connector.ParseData();
    }
}
