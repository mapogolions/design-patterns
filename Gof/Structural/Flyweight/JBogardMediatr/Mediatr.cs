using Gof.Structural.Flyweight.JBogardMediatr.Internal;

namespace Gof.Structural.Flyweight.JBogardMediatr
{
    public class Mediatr
    {
        private readonly ServiceProvider _services;

        public Mediatr(ServiceProvider services)
        {
            _services = services;
        }

        public TRes Send<TRes>(IRequest<TRes> request)
        {
            var requestType = request.GetType();
            var route = new Route<TRes>(request);
            return route.Invoke(_services);
        }

        public TRes SendOptimized<TRes>(IRequest<TRes> request)
        {
            var requestType = request.GetType();
            var handler = RequestEndpointsFactory.Create<TRes>(requestType);
            return (TRes)handler.Act(request, _services);
        }
    }
}
