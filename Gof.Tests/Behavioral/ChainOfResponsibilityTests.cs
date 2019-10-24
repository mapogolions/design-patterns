using Gof.Behavioral.ChainOfResponsibility;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class ChainOfResponsibilityTests
    {
        [Fact]
        public void IdentityShouldReturnFalseWhenNextMiddlewareIsNull()
        {
            var chain = new IdentityMiddleware();
            Assert.False(chain.Check(string.Empty));
        }

        [Fact]
        public void NotShouldReturnTrueWhenNextMiddlewareIsNull()
        {
            var chain = new NotMiddleware();
            Assert.True(chain.Check(string.Empty));
        }

        [Fact]
        public void TwiceNotShouldReturnFalse()
        {
            var chain = new NotMiddleware();
            chain.LinkWith(new NotMiddleware());
            Assert.False(chain.Check(string.Empty));
        }
    }
}
