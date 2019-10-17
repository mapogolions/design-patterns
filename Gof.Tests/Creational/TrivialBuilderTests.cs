using Gof.Creational.Builder.Trivial;
using Xunit;

namespace Gof.Tests.Creational
{
    public class TrivialBuilderTests
    { 
        [Theory]
        [InlineData(404, "1.1", "Page not found")]
        [InlineData(500, "1.0", "Internal server error")]
        [InlineData(204, "2.0", "No content")]
        public void ShouldReturnResponseOnlyWithStatusLine(int statusCode, string protocol, string reasonPhrase)
        {
            var response = new HttpResponse
                .InternalBuilder(statusCode, protocol)
                .WithReasonPhrase(reasonPhrase)
                .Build();
            var expected = $"HTTP/{protocol} {statusCode} {reasonPhrase}".TrimEnd() + "\n\n";
            Assert.Equal(expected, response.ToString());
        }
    }
}
