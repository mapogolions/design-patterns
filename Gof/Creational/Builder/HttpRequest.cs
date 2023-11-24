namespace Gof.Creational.Builder;

public class HttpRequest
{
    private readonly string _method;
    private readonly string _uri;
    private readonly string _protocolVersion;
    private readonly string? _queryString;

    private HttpRequest(string method, string uri, string protocolVersion, string? queryString)
    {
        _method = method;
        _uri = uri;
        _protocolVersion = protocolVersion;
        _queryString = queryString;
    }

    public override string ToString()
    {
        var statusLine = $"{_method} {_uri}{_queryString} HTTP/{_protocolVersion}";
        return $"{statusLine}\r\n\r\n";
    }

    public class Builder
    {
        private string? _method;
        private string? _uri;
        private string? _protocolVersion;
        private string? _queryString;

        public Builder WithMethod(string method)
        {
            ArgumentNullException.ThrowIfNull(method);
            _method = method;
            return this;
        }

        public Builder WithUri(string uri)
        {
            ArgumentNullException.ThrowIfNull(uri);
            _uri = uri;
            return this;
        }

        public Builder WithProtocolVersion(string protocolVersion)
        {
            ArgumentNullException.ThrowIfNull(protocolVersion);
            _protocolVersion = protocolVersion;
            return this;
        }

        public Builder WithQueryString(string queryString)
        {
            _queryString = queryString;
            return this;
        }

        public HttpRequest Build()
        {
            ArgumentNullException.ThrowIfNull(_method);
            ArgumentNullException.ThrowIfNull(_uri);
            ArgumentNullException.ThrowIfNull(_protocolVersion);
            return new HttpRequest(_method, _uri, _protocolVersion, _queryString);
        }
    }
}
