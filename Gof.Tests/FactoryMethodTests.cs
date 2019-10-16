using Gof.FactoryMethod;
using Gof.FactoryMethod.Concrete;
using Xunit;

namespace Gof.Tests
{
    public class FactoryMethodTests
    {
        [Fact]
        public void ParseDataShouldReturnXmlFormatWhenConnectionIsEstablishedWithXmlDataSource()
        {
            var factoryMethodDemo = new FakeFactoryMethod { Connection = new XmlConnection() };
            var expected = "<format>xml</format>";
            Assert.Equal(expected, factoryMethodDemo.ParseData());
        }

        [Fact]
        public void ParseDataShouldReturnIniFormatWhenConnectionIsEstablishedWithIniDataSource()
        {
            var factoryMethodDemo = new FakeFactoryMethod { Connection = new IniConnection() };
            var expected = "[ini format]";
            Assert.Equal(expected, factoryMethodDemo.ParseData());
        }
    }
}
