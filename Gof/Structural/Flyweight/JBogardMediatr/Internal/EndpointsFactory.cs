using System;
using System.Collections.Concurrent;

namespace Gof.Structural.Flyweight.JBogardMediatr.Internal
{
    internal static class EndpointsFactory
    {
        private static readonly ConcurrentDictionary<Type, UntypedEndpoint> _endpoints = new();

        public static UntypedEndpoint Match<TRes>(Type requestType) =>
            _endpoints.GetOrAdd(requestType,
                static t => (UntypedEndpoint)(Activator.CreateInstance(typeof(TypedEndpoint<,>)
                .MakeGenericType(t, typeof(TRes))) ?? throw new InvalidOperationException()));
    }
}
