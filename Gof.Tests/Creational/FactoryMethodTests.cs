using Gof.Creational.FactoryMethod;
using Gof.Creational.FactoryMethod.Concrete;
using Xunit;

namespace Gof.Tests
{
    public class FactoryMethodTests
    {
        [Fact]
        public void ParseDataShouldReturnXmlFormatWhenConnectionIsEstablishedWithXmlDataSource()
        {
            var factoryMethodDemo = new FakeClient(new XmlConnection());
            var expected = "<format>xml</format>";
            Assert.Equal(expected, factoryMethodDemo.ParseData());
        }

        [Fact]
        public void ParseDataShouldReturnIniFormatWhenConnectionIsEstablishedWithIniDataSource()
        {
            var factoryMethodDemo = new FakeClient(new IniConnection());
            var expected = "[ini format]";
            Assert.Equal(expected, factoryMethodDemo.ParseData());
        }
    }
}
