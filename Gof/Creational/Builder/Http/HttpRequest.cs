namespace Gof.Creational.Builder.Http;

public class HttpRequest : HttpMessage
{
    // required
    private readonly string _method;
    private readonly string _uri;
    // optional
    private readonly string _queryString;

    private HttpRequest(Builder builder) : base(builder)
    {
        _method = builder.Method;
        _uri = builder.Uri;
        _queryString = builder.QueryString;
    }

    public override string ToString()
    {
        var statusLine = $"{_method} {_uri}{_queryString} HTTP/{_protocolVersion}";
        return $"{statusLine}\r\n{base.ToString()}";
    }

    public class Builder : MessageBuilder
    {
        // required
        protected internal string Method { get; private set; }
        protected internal string Uri { get; private set; }
        // optional
        protected internal string QueryString { get; private set; }

        public Builder(string method, string uri) : this(method, uri, "1.1") {}

        public Builder(string method, string uri, string protocolVersion) : base(protocolVersion)
        {
            Method = method;
            Uri = uri;
            QueryString = default;
        }

        public Builder WithQueryString(string queryString)
        {
            QueryString = queryString;
            return this;
        }

        public override HttpMessage Build() => new HttpRequest(this);
    }
}
