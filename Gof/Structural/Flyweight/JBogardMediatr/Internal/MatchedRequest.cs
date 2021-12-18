namespace Gof.Structural.Flyweight.JBogardMediatr.Internal
{
    internal readonly ref struct MatchedRequest<TRes>
    {
        private readonly object _request;
        private readonly UntypedRequestEndpoint _endpoint;
        private readonly ServiceProvider _services;

        public MatchedRequest(object request, ServiceProvider services)
        {
            _request = request;
            _services = services;
            _endpoint = RequestEndpointsFactory.Match<TRes>(request.GetType());
        }

        public TRes Respose() => (TRes)_endpoint.Act(_request, _services);
    }
}
