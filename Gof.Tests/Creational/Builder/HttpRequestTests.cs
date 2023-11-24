using Gof.Creational.Builder;

namespace Gof.Tests.Creational.Builder;

public class HierarchicalHttpRequestTests
{
    [Theory]
    [InlineData("GET", "/home", "1.0")]
    [InlineData("PUT", "/update", "1.1")]
    public void ShouldProvideAllRequiredParametersForHttpRequest(string method, string uri, string protocolVersion)
    {
        var request = new HttpRequest.Builder()
            .WithMethod(method)
            .WithUri(uri)
            .WithProtocolVersion(protocolVersion)
            .Build();
        var expected = $"{method} {uri} HTTP/{protocolVersion}\r\n\r\n";
        Assert.Equal(expected, request.ToString());
    }

    [Theory]
    [InlineData("GET", "/user", "?id=1")]
    [InlineData("DELETE", "/article", "?id=10")]
    [InlineData("PATCH", "/user", "?id=2")]
    public void ShouldReturnStatusLineWithQueryString(string method, string uri, string queryString)
    {
        var request = new HttpRequest.Builder()
            .WithMethod(method)
            .WithUri(uri)
            .WithProtocolVersion("1.1")
            .WithQueryString(queryString)
            .Build();

        var expected = $"{method} {uri}{queryString} HTTP/1.1\r\n\r\n";
        Assert.Equal(expected, request.ToString());
    }
}
