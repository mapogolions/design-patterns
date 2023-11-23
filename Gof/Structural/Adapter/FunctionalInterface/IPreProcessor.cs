namespace Gof.Structural.Adapter.FunctionalInterface;

public interface IPreProcessor<in TRequest>
{
    void Process(TRequest request);
}
