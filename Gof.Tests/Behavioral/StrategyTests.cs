using Gof.Behavioral.Strategy;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class StrategyTests
    {
        [Theory]
        [InlineData("user name", "user_name")]
        [InlineData("identity", "identity")]
        [InlineData("potential real profit", "potential_real_profit")]
        public void ShouldConvertToSnakeCaseNotation(string identifier, string expected)
        {
            var context = new Context(notation: new SnakeCaseNotation());
            Assert.Equal(expected, context.Convert(identifier));
        }

        [Theory]
        [InlineData("user name", "UserName")]
        [InlineData("identity", "Identity")]
        [InlineData("potential real profit", "PotentialRealProfit")]
        public void ShouldConvertToPascalCaseNotation(string identifier, string expected)
        {
            var context = new Context(notation: new PascalCaseNotation());
            Assert.Equal(expected, context.Convert(identifier));
        }

        [Theory]
        [InlineData("user name", "user-name")]
        [InlineData("identity", "identity")]
        [InlineData("potential real profit", "potential-real-profit")]
        public void ShouldConvertToHyphenNotation(string identifier, string expected)
        {
            var context = new Context(notation: new HyphenNotation());
            Assert.Equal(expected, context.Convert(identifier));
        }


        [Theory]
        [InlineData("user name", "userName")]
        [InlineData("identity", "identity")]
        [InlineData("potential real profit", "potentialRealProfit")]
        public void ShouldConvertToCamelCaseNotation(string identifier, string expected)
        {
            var context = new Context(notation: new CamelCaseNotation());
            Assert.Equal(expected, context.Convert(identifier));
        }
    }
}
