
namespace Gof.Behavioral.State.CircuitBreaker
{
    public partial class CircuitBreaker<T>
    {
        private interface ICircuitState
        {
            bool IsOpen { get; }
            void Success();
            void Fail(T result, Exception error);
        }
    }
}
