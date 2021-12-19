namespace Gof.Structural.Flyweight.JBogardMediatr.Internal
{
    internal readonly ref struct Matching<TRes>
    {
        private readonly object _request;
        private readonly UntypedEndpoint _endpoint;
        private readonly ServiceProvider _services;

        public Matching(object request, ServiceProvider services)
        {
            _request = request;
            _services = services;
            _endpoint = EndpointsFactory.Match<TRes>(request.GetType());
        }

        public TRes Invoke() => (TRes)_endpoint.Act(_request, _services);
    }
}
