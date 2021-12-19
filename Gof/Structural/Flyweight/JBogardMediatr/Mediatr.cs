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
            var matching = new Matching<TRes>(request, _services);
            return matching.Invoke();
        }

        public TRes SendOptimized<TRes>(IRequest<TRes> request)
        {
            var requestType = request.GetType();
            var endpoint = EndpointsFactory.Match<TRes>(requestType);
            return (TRes)endpoint.Act(request, _services);
        }
    }
}
