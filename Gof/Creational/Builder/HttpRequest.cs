namespace Gof.Creational.Builder;

public class HttpRequest
{
    private readonly string _method;
    private readonly string _uri;
    private readonly string _protocolVersion;
    private readonly string? _queryString;

    private HttpRequest(Builder builder)
    {
        _method = builder.Method;
        _uri = builder.Uri;
        _protocolVersion = builder.ProtocolVersion;
        _queryString = builder.QueryString;
    }

    public override string ToString()
    {
        var statusLine = $"{_method} {_uri}{_queryString} HTTP/{_protocolVersion}";
        return $"{statusLine}\r\n\r\n";
    }

    public class Builder
    {
        // required
        protected internal string Method { get; private set; }
        protected internal string Uri { get; private set; }
        protected internal string ProtocolVersion { get; private set; }
        // optional
        protected internal string? QueryString { get; private set; }

        public Builder(string method, string uri, string protocolVersion = "1.1")
        {
            Method = method;
            Uri = uri;
            ProtocolVersion = protocolVersion;
        }

        public Builder WithQueryString(string queryString)
        {
            QueryString = queryString;
            return this;
        }

        public HttpRequest Build() => new HttpRequest(this);
    }
}
