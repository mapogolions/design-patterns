namespace Gof.Creational.Builder.Hierarchical
{
    public class HttpResponse : HttpMessage
    {
        private readonly int _statusCode;
        private readonly string _reasonPhrase;

        private HttpResponse(InternalBuilder builder) : base(builder)
        {
            _statusCode = builder.StatusCode;
            _reasonPhrase = builder.ReasonPhrase;
        }

        public override string ToString()
        {
            var statusLine = $"HTTP/{_protocolVersion} {_statusCode} {_reasonPhrase}".TrimEnd();
            return $"{statusLine}\n{base.ToString()}";
        }

        public class InternalBuilder : MessageBuilder
        {
            // require for HttpResponse
            protected internal int StatusCode { get; private set; }
            // optional for HttpResponse
            protected internal string ReasonPhrase { get; private set; }

            public InternalBuilder(int statusCode) : this(statusCode, "1.1") {}
            public InternalBuilder(int statusCode, string protocolVersion) : base(protocolVersion) =>
                StatusCode = statusCode;

            public InternalBuilder WithReasonPhrase(string reasonPhrase)
            {
                ReasonPhrase = reasonPhrase;
                return this;
            }

            public override HttpMessage Build() => new HttpResponse(this);
        }
    }
}
