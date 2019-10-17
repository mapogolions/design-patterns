using Gof.Creational.Builder.Trivial;
using Xunit;

namespace Gof.Tests.Creational
{
    public class TrivialBuilderTests
    {
        [Theory]
        [InlineData(404, "HTTP/1.1", "Page not found")]
        [InlineData(500, "HTTP/1.0", "Internal server error")]
        [InlineData(204, "HTTP/2.0", "No content")]
        public void ShouldReturnStatusLineWithoutHeadersAndBody(int statusCode, string protocol, string reasonPhrase)
        {
            var pageNotFound = new HttpMessage
                .InternalBuilder(statusCode, protocol)
                .WithReasonPhrase(reasonPhrase)
                .Build();
            var expected = $"{statusCode} {protocol} {reasonPhrase}".Trim() + "\n\n";
            Assert.Equal(expected, pageNotFound.ToString());
        }
    }
}
