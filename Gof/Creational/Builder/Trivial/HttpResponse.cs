using System.Collections.Generic;

namespace Gof.Creational.Builder.Trivial
{
    public class HttpResponse
    {
        private readonly int _statusCode;
        private readonly string _reasonPhrase;
        private readonly string _protocol;
        private readonly ISet<string> _headers;
        private readonly string _body;

        private HttpResponse(InternalBuilder builder)
        {
            _statusCode = builder.StatusCode;
            _reasonPhrase = builder.ReasonPhrase;
            _protocol = builder.Protocol;
            _headers = builder._headers;
            _body = builder.Body;
        }

        public override string ToString()
        {
            var statusLine = $"{_statusCode} {_protocol} {_reasonPhrase}".TrimEnd();
            var headers = "";
            foreach (var header in _headers)
                headers += $"header\n";
            return $"{statusLine}\n{headers}\n{_body}";
        }

        public class InternalBuilder
        {
            // required
            public int StatusCode { get; private set; }
            public string Protocol { get; private set; }

            // optional
            public readonly ISet<string> _headers = new HashSet<string>(); 
            public string ReasonPhrase { get; private set; }
            public string Body { get; private set; }

            public InternalBuilder(int statusCode, string protocol)
            {
                StatusCode = statusCode;
                Protocol = protocol;
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
