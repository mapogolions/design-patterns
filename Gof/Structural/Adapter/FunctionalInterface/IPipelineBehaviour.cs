using System;

namespace Gof.Structural.Adapter.FunctionalInterface
{
    public interface IPipelineBehaviour<TRequest, TResponse>
    {
        TResponse Handle(TRequest request, Func<TRequest, TResponse> next);
    }
}
