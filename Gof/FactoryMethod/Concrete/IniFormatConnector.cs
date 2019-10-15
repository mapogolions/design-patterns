using Gof.FactoryMethod.Abs;

namespace Gof.FactoryMethod.Concrete
{
    public class IniFormatConnector : IDataConnector
    {
        public string ParseData()
        {
            return "[ini format]";
        }
    }

}