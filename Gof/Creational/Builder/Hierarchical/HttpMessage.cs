using System.Collections.Generic;

namespace Gof.Creational.Builder.Hierarchical
{
    public abstract class HttpMessage
    {
        public string ProtocolVersion { get; private set; }
        public ISet<string> Headers { get; private set; }
        public string Body { get; private set; }

        public HttpMessage(MessageBuilder builder)
        {
            ProtocolVersion = builder.ProtocolVersion;
            Headers = builder._headers;
            Body = builder.Body;
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
