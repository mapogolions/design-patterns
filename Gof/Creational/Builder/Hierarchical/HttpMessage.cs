using System.Collections.Generic;

namespace Gof.Creational.Builder.Hierarchical
{
    public abstract class HttpMessage
    {
        private readonly string _protocolVersion;
        public readonly ISet<string> _headers;
        private readonly string _body;

        public HttpMessage(MessageBuilder builder)
        {
            _protocolVersion = builder.ProtocolVersion;
            _headers = builder._headers;
            _body = builder.Body;
        }

        public abstract class MessageBuilder
        {
            // required
            protected internal string ProtocolVersion { get; private set; }
            // optional
            protected internal readonly ISet<string> _headers = new HashSet<string>();
            protected internal string Body { get; private set; }

            protected MessageBuilder(string protocolVersion) => ProtocolVersion = protocolVersion;

            public abstract HttpMessage Build();

            public MessageBuilder WithHeader(string header)
            {
                _headers.Add(header);
                return this;
            }

            public MessageBuilder WithBody(string body)
            {
                Body = body;
                return this;
            }
        }
    }
}
