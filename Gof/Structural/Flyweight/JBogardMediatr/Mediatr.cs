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
            var matchedRequest = new MatchedRequest<TRes>(request, _services);
            return matchedRequest.Respose();
        }

        public TRes SendOptimized<TRes>(IRequest<TRes> request)
        {
            var requestType = request.GetType();
            var endpoint = RequestEndpointsFactory.Match<TRes>(requestType);
            return (TRes)endpoint.Act(request, _services);
        }
    }
}
