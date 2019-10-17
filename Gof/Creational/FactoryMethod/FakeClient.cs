using Gof.Creational.FactoryMethod.Abs;

namespace Gof.Creational.FactoryMethod
{
    public class FakeClient
    {
        private readonly IConnection _connection;
        public FakeClient(IConnection connection) => _connection = connection;
        public string ParseData() => _connection.Connector.ParseData();
    }
}
