using System;
using System.Collections.Concurrent;

namespace Gof.Structural.Flyweight.JBogardMediatr.Internal
{
    internal class RequestHandlersFactory
    {
        private static readonly ConcurrentDictionary<Type, RequestHandlerBase> _handlers = new();

        public RequestHandlerBase Create<TRes>(Type requestType)
        {
            return (RequestHandlerBase) _handlers.GetOrAdd(requestType,
                static t => (RequestHandlerBase)(Activator.CreateInstance(typeof(RequestHandlerWrapper<,>).MakeGenericType(t, typeof(TRes)))
                ?? throw new InvalidOperationException()));
        }
    }
}
