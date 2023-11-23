namespace Gof.Structural.Adapter.FunctionalInterface;

public class PreProcessorAdapter<TRequest>(Action<TRequest> action) : IPreProcessor<TRequest>
{
    private readonly Action<TRequest> _action = action;

    public void Process(TRequest request) => _action(request);
}
