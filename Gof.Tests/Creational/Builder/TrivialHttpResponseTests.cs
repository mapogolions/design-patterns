using Gof.Creational.Builder.Trivial;
using Xunit;

namespace Gof.Tests.Creational.Builder
{
    public class TrivialHttpResponseTests
    {
        [Theory]
        [InlineData(200, "1.1", "Content-type: text/plain; charset=utf-8")]
        [InlineData(200, "1.1", "Cache-control: No")]
        public void ShoudReturnResponseWithSomeHeader(int statusCode, string protocolVersion, string header)
        {
            var response = new HttpResponse
                .InternalBuilder(statusCode, protocolVersion)
                .WithHeader(header)
                .Build();
            var expected = $"HTTP/{protocolVersion} {statusCode}\r\n{header}\r\n\r\n";
            Assert.Equal(expected, response.ToString());
        }

        [Theory]
        [InlineData(404, "1.1", "Page not found")]
        [InlineData(500, "1.0", "Internal server error")]
        [InlineData(204, "2.0", "No content")]
        public void ShouldReturnResponseOnlyWithStatusLine(int statusCode, string protocolVersion, string reasonPhrase)
        {
            var response = new HttpResponse
                .InternalBuilder(statusCode, protocolVersion)
                .WithReasonPhrase(reasonPhrase)
                .Build();
            var expected = $"HTTP/{protocolVersion} {statusCode} {reasonPhrase}".TrimEnd() + "\r\n\r\n";
            Assert.Equal(expected, response.ToString());
        }

        [Fact]
        public void ShoudReturnHelloWorldPhraseAsPlainText()
        {
            var statusCode = 200;
            var protocolVersion = "1.1";
            var reasonPhrase = "Ok";
            var contentTypeHeader = "Content-Type: text/plain; charset=utf-8";
            var body = "Hello world";

            var response = new HttpResponse
                .InternalBuilder(statusCode, protocolVersion)
                .WithHeader(contentTypeHeader)
                .WithBody(body)
                .WithReasonPhrase(reasonPhrase)
                .Build();

            var expected = $"HTTP/{protocolVersion} {statusCode} {reasonPhrase}\r\n{contentTypeHeader}\r\n\r\n{body}";

            Assert.Equal(expected, response.ToString());
        }
    }
}
