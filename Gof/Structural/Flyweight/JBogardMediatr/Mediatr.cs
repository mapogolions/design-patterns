using System;
using System.Collections.Concurrent;

namespace Gof.Structural.Flyweight.JBogardMediatr
{
    public class Mediatr
    {
        private static readonly ConcurrentDictionary<Type, RequestHandlerBase> _handlers = new();

        private readonly ServiceProvider _services;

        public Mediatr(ServiceProvider services)
        {
            _services = services;
        }

        public TRes Send<TRes>(IRequest<TRes> request)
        {
            var requestType = request.GetType();
            var handler = (RequestHandlerBase) _handlers.GetOrAdd(requestType,
                static t => (RequestHandlerBase)(Activator.CreateInstance(typeof(RequestHandlerWrapper<,>).MakeGenericType(t, typeof(TRes)))
                ?? throw new InvalidOperationException()));
            return (TRes) handler.Handle(request, _services);
        }
    }
}
