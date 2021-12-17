using System;
using System.Collections.Concurrent;

namespace Gof.Structural.Flyweight.JBogardMediatr.Internal
{
    internal static class RequestEndpointsFactory
    {
        private static readonly ConcurrentDictionary<Type, UntypedRequestEndpoint> _endpoints = new();

        public static UntypedRequestEndpoint Match<TRes>(Type requestType) =>
            _endpoints.GetOrAdd(requestType,
                static t => (UntypedRequestEndpoint)(Activator.CreateInstance(typeof(TypedRequestEndpoint<,>)
                .MakeGenericType(t, typeof(TRes))) ?? throw new InvalidOperationException()));
    }
}
