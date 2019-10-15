using System.Linq;
using Xunit;

namespace Gof.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Contains(1, Enumerable.Range(1, 10));
        }
    }
}
