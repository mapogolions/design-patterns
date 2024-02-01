
namespace Gof.Behavioral.State.CircuitBreaker
{
    public partial class CircuitBreaker<T>
    {
        private class CircuitHalfOpenState : ICircuitState
        {
            private readonly CircuitBreaker<T> _circuitBreaker;

            public CircuitHalfOpenState(CircuitBreaker<T> circuitBreaker)
            {
                _circuitBreaker = circuitBreaker ?? throw new ArgumentNullException(nameof(circuitBreaker));
            }

            public bool IsOpen => false;

            public void Fail(T result, Exception error)
            {
                _circuitBreaker.Set(result, error);
                _circuitBreaker.Open();
                _circuitBreaker.SetBreakTill();
            }

            public void Success()
            {
                _circuitBreaker.Reset();
            }
        }
    }
}
