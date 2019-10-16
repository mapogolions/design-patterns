using Gof.Creational.FactoryMethod.Abs;

namespace Gof.Creational.FactoryMethod.Concrete
{
    public class IniFormatConnector : IDataConnector
    {
        public string ParseData()
        {
            return "[ini format]";
        }
    }

}
