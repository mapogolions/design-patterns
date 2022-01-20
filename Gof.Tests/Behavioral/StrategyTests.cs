using Gof.Behavioral.Strategy;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class StrategyTests
    {
        [Theory]
        [InlineData("token", "token")]
        [InlineData("cancellation token", "cancellation_token")]
        [InlineData("cancellation token source", "cancellation_token_source")]
        public void ShouldConvertToSnakeCaseNotation(string name, string expected)
        {
            var context = new Context(new SnakeCaseNotation());
            Assert.Equal(expected, context.Convert(name));
        }

        [Theory]
        [InlineData("token", "Token")]
        [InlineData("cancellation token", "CancellationToken")]
        [InlineData("cancellation token source", "CancellationTokenSource")]
        public void ShouldConvertToPascalCaseNotation(string name, string expected)
        {
            var context = new Context(new PascalCaseNotation());
            Assert.Equal(expected, context.Convert(name));
        }

        [Theory]
        [InlineData("token", "token")]
        [InlineData("cancellation token", "cancellation-token")]
        [InlineData("cancellation token source", "cancellation-token-source")]
        public void ShouldConvertToHyphenNotation(string name, string expected)
        {
            var context = new Context(new HyphenNotation());
            Assert.Equal(expected, context.Convert(name));
        }


        [Theory]
        [InlineData("token", "token")]
        [InlineData("cancellation token", "cancellationToken")]
        [InlineData("cancellation token source", "cancellationTokenSource")]
        public void ShouldConvertToCamelCaseNotation(string name, string expected)
        {
            var context = new Context(new CamelCaseNotation());
            Assert.Equal(expected, context.Convert(name));
        }
    }
}
