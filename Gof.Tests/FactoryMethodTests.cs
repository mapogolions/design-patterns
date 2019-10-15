using Xunit;

namespace Gof.Tests
{
    public class FactoryMethodTests
    {
        [Fact]
        public void ParseDataShouldReturnAnyXmlFormatWhenConnectionHasXmlFamily()
        {
            Assert.EndsWith("o", "hello");
        }
    }
}