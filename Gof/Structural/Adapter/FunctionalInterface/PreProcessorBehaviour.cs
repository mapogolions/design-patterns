namespace Gof.Structural.Adapter.FunctionalInterface;

public class PreProcessorBehaviour<TRequest, TResponse>(IEnumerable<IPreProcessor<TRequest>> preprocessors)
    : IPipelineBehaviour<TRequest, TResponse>
{
    private readonly IEnumerable<IPreProcessor<TRequest>> _preprocessors = preprocessors;

    public TResponse Handle(TRequest request, Func<TRequest, TResponse> next)
    {
        foreach (var preprocessor in _preprocessors)
        {
            preprocessor.Process(request);
        }
        return next(request);
    }
}
