using Gof.Creational.Builder.Trivial;
using Xunit;

namespace Gof.Tests.Creational
{
    public class TrivialBuilderTests
    { 
        [Theory]
        [InlineData(200, "1.1", "Content-type: text/plain; charset=utf-8")]
        [InlineData(200, "1.1", "Cache-control: No")]
        public void ShoudReturnResponseWithSomeHeader(int statusCode, string protocol, string header)
        {
            var response = new HttpResponse
                .InternalBuilder(200, "1.1")
                .WithHeader(header)
                .Build();
            var expected = $"HTTP/{protocol} {statusCode}\n{header}\n\n";
            Assert.Equal(expected, response.ToString());
        }

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

        [Fact]
        public void ShoudReturnHelloWorldPhraseAsPlainText()
        {
            var statusCode = 200;
            var protocol = "1.1";
            var reasonPhrase = "Ok";
            var contentTypeHeader = "Content-Type: text/plain; charset=utf-8";

            var body = "Hello world";
            var response = new HttpResponse
                .InternalBuilder(statusCode, protocol)
                .WithHeader(contentTypeHeader)
                .WithBody(body)
                .WithReasonPhrase(reasonPhrase)
                .Build();

            var expected = $"HTTP/{protocol} {statusCode} {reasonPhrase}\n{contentTypeHeader}\n\n{body}";

            Assert.Equal(expected, response.ToString());
        }
    }
}
