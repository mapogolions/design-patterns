using Gof.Creational.Builder.Hierarchical;
using Xunit;

namespace Gof.Tests.Creational.Builder
{
    public class HierarchicalHttpRequestTests
    {
        [Theory]
        [InlineData("GET", "/")]
        [InlineData("POST", "/create")]
        public void ShouldReturnStatusLineWithDefaultProtocolVersion(string method, string uri)
        {
            var request = new HttpRequest.InternalBuilder(method, uri).Build();
            var expected = $"{method} {uri} HTTP/1.1\r\n\r\n";
            Assert.Equal(expected, request.ToString());
        }

        [Theory]
        [InlineData("GET", "/home", "1.0")]
        [InlineData("PUT", "/update", "1.1")]
        public void ShouldProvideAllRequiredParametersForHttpRequest(string method, string uri, string protocolVersion)
        {
            var request = new HttpRequest.InternalBuilder(method, uri, protocolVersion).Build();
            var expected = $"{method} {uri} HTTP/{protocolVersion}\r\n\r\n";
            Assert.Equal(expected, request.ToString());
        }

        [Theory]
        [InlineData("GET", "/user", "?id=1")]
        [InlineData("DELETE", "/article", "?id=10")]
        [InlineData("PATCH", "/user", "?id=2")]
        public void ShouldReturnStatusLineWithQueryString(string method, string uri, string queryString)
        {
            var request = new HttpRequest
                .InternalBuilder(method, uri)
                .WithQueryString(queryString)
                .Build();

            var expected = $"{method} {uri}{queryString} HTTP/1.1\r\n\r\n";
            Assert.Equal(expected, request.ToString());
        }
    }
}
