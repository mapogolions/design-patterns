using Gof.FactoryMethod.Abs;

namespace Gof.FactoryMethod.Concrete
{
    public class XmlFormatConnector : IDataConnector
    {
        public string ParseData()
        {
            return "<format>xml</format>";
        }
    }
}
