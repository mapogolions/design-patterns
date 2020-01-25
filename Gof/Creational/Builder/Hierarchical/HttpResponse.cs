namespace Gof.Creational.Builder.Hierarchical
{
    public class HttpResponse : HttpMessage
    {
        private readonly int _statusCode;
        private readonly string _reasonPhrase;

        private HttpResponse(Builder builder) : base(builder)
        {
            _statusCode = builder.StatusCode;
            _reasonPhrase = builder.ReasonPhrase;
        }

        public override string ToString()
        {
            var statusLine = $"HTTP/{_protocolVersion} {_statusCode} {_reasonPhrase}".TrimEnd();
            return $"{statusLine}\r\n{base.ToString()}";
        }

        public class Builder : MessageBuilder
        {
            // required
            protected internal int StatusCode { get; private set; }
            // optional
            protected internal string ReasonPhrase { get; private set; }

            public Builder(int statusCode) : this(statusCode, "1.1") {}
            public Builder(int statusCode, string protocolVersion) : base(protocolVersion) =>
                StatusCode = statusCode;

            public Builder WithReasonPhrase(string reasonPhrase)
            {
                ReasonPhrase = reasonPhrase;
                return this;
            }

            public override HttpMessage Build() => new HttpResponse(this);
        }
    }
}
