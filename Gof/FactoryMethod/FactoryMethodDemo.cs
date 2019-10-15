using Gof.FactoryMethod.Abs;

namespace Gof.FactoryMethod
{
    public class FactoryMethodDemo
    {
        public IConnection Connection { get; set; }

        public string ParseData() => Connection.Connector.ParseData();
    }
}