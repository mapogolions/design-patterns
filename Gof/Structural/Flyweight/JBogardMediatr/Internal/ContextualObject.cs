namespace Gof.Structural.Flyweight.JBogardMediatr.Internal
{
    internal readonly ref struct ContextualObject
    {
        private readonly object _request;
        private readonly RequestHandlerBase _handler;
        private readonly ServiceProvider _services;

        public ContextualObject(object request, RequestHandlerBase handler, ServiceProvider services)
        {
            _request = request;
            _handler = handler;
            _services = services;
        }

        public object Handle() => _handler.Handle(_request, _services);
    }
}
