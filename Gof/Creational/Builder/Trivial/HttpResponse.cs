using System.Collections.Generic;

namespace Gof.Creational.Builder.Trivial
{
    public class HttpResponse
    {
        private readonly int _statusCode;
        private readonly string _reasonPhrase;
        private readonly string _protocolVersion;
        private readonly ISet<string> _headers;
        private readonly string _body;

        private HttpResponse(InternalBuilder builder)
        {
            _statusCode = builder.StatusCode;
            _reasonPhrase = builder.ReasonPhrase;
            _protocolVersion = builder.ProtocolVersion;
            _headers = builder._headers;
            _body = builder.Body;
        }

        public override string ToString()
        {
            var statusLine = $"HTTP/{_protocolVersion} {_statusCode} {_reasonPhrase}".TrimEnd();
            var headers = "";
            foreach (var header in _headers)
                headers += $"{header}\n";
            return $"{statusLine}\n{headers}\n{_body}";
        }

        public class InternalBuilder
        {
            // required
            protected internal int StatusCode { get; private set; }
            protected internal string ProtocolVersion { get; private set; }

            // optional
            protected internal readonly ISet<string> _headers = new HashSet<string>(); 
            protected internal string ReasonPhrase { get; private set; }
            protected internal string Body { get; private set; }

            public InternalBuilder(int statusCode, string protocolVersion)
            {
                StatusCode = statusCode;
                ProtocolVersion = protocolVersion;
            }

            public InternalBuilder WithHeader(string header)
            {
                _headers.Add(header);
                return this;
            }

            public InternalBuilder WithReasonPhrase(string reasonPhrase)
            {
                ReasonPhrase = reasonPhrase;
                return this;
            }

            public InternalBuilder WithBody(string body)
            {
                Body = body;
                return this;
            }

            public HttpResponse Build() => new HttpResponse(this);
        }
    }
}
