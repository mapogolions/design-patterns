using Gof.Creational.FactoryMethod.Abs;

namespace Gof.Creational.FactoryMethod.Concrete
{
    public class XmlFormatConnector : IDataConnector
    {
        public string ParseData()
        {
            return "<format>xml</format>";
        }
    }
}
