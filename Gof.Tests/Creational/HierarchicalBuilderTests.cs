using Gof.Creational.Builder.Hierarchical;
using Xunit;

namespace Gof.Tests.Creational
{
    public class HierarchicalBuilderTests
    {
        [Theory]
        [InlineData(200)]
        [InlineData(302)]
        public void ShouldReturnStatusLineWithStatusCodeAndDefaultProtocolVersion(int statusCode)
        {
            var response = new HttpResponse.InternalBuilder(statusCode).Build();
            Assert.Equal($"HTTP/1.1 {statusCode}\n\n", response.ToString());
        }

        [Theory]
        [InlineData(200, "1.1")]
        [InlineData(302, "1.0")]
        public void ShouldReturnStatusLineWithSpecifiedStatusCodeAndProtocolVersion(int statusCode, string protocolVersion)
        {
            var response = new HttpResponse.InternalBuilder(statusCode, protocolVersion).Build();
            Assert.Equal($"HTTP/{protocolVersion} {statusCode}\n\n", response.ToString());
        }

        [Theory]
        [InlineData(200, "Ok")]
        [InlineData(204, "No Content")]
        [InlineData(404, "Not Found")]
        [InlineData(302, "Redirect")]
        public void ShouldReturnStatusLineWithReasonPhrase(int statusCode, string reasonPhrase)
        {
            var response = new HttpResponse
                .InternalBuilder(statusCode)
                .WithReasonPhrase(reasonPhrase)
                .Build();
            var expected = $"HTTP/1.1 {statusCode} {reasonPhrase}\n\n";
            Assert.Equal(expected, response.ToString());
        }

        [Theory]
        [InlineData("Content-Type: application/json; charset=utf-8")]
        [InlineData("Cache-Control: no")]
        public void ShouldReturnResponseWithStatusLineAndSomeHeader(string header)
        {
            var response = new HttpResponse
                .InternalBuilder(200)
                .WithHeader(header)
                .Build();
            var expected = $"HTTP/1.1 200\n{header}\n\n";
            Assert.Equal(expected, response.ToString());
        }

        [Theory]
        [InlineData("Content-Type: text/plain; charset=utf-8", "Hello world")]
        [InlineData("Content-Type: application/json; charset=utf-8", "{\"name\": null}")]
        public void ShouldReturnResponseWithBody(string header, string body)
        {
            var response = new HttpResponse
                .InternalBuilder(200)
                .WithReasonPhrase("Ok")
                .WithHeader(header)
                .WithBody(body)
                .Build();
            var expected = $"HTTP/1.1 200 Ok\n{header}\n\n{body}";
            Assert.Equal(expected, response.ToString());
        }
    }
}
