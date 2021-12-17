namespace Gof.Structural.Flyweight.JBogardMediatr.Internal
{
    internal readonly ref struct Route<TRes>
    {
        private readonly object _request;
        private readonly UntypedRequestEndpoint _endpoint;

        public Route(object request)
        {
            _request = request;
            _endpoint = RequestEndpointsFactory.Match<TRes>(request.GetType());
        }

        public TRes Invoke(ServiceProvider services) => (TRes)_endpoint.Act(_request, services);
    }
}
