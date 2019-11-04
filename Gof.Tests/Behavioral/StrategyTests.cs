using System.Collections.Generic;
using Gof.Behavioral.Strategy;
using Xunit;

namespace Gof.Tests
{
    public class StrategyTests
    {
        [Theory]
        [InlineData("user name", "user_name")]
        [InlineData("identity", "identity")]
        [InlineData("potential real profit", "potential_real_profit")]
        public void ShouldConvertToSnakeCaseNotation(string name, string expected)
        {
            var context = new Context(notation: new SnakeCaseNotation());
            Assert.Equal(expected, context.Convert(name));
        }
    }
}
