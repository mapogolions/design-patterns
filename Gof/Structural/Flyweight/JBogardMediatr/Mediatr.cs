using Gof.Structural.Flyweight.JBogardMediatr.Internal;

namespace Gof.Structural.Flyweight.JBogardMediatr
{
    public class Mediatr
    {
        private static RequestHandlersFactory _factory = new();

        private readonly ServiceProvider _services;

        public Mediatr(ServiceProvider services)
        {
            _services = services;
        }

        public TRes Send<TRes>(IRequest<TRes> request)
        {
            var requestType = request.GetType();
            var context = new ContextualObject(request, _factory.Create<TRes>(requestType), _services);
            return (TRes)context.Handle();
        }

        public TRes SendOptimized<TRes>(IRequest<TRes> request)
        {
            var requestType = request.GetType();
            var handler = _factory.Create<TRes>(requestType);
            return (TRes) handler.Handle(request, _services);
        }
    }
}
