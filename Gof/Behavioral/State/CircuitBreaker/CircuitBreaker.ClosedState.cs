
namespace Gof.Behavioral.State.CircuitBreaker
{
    public partial class CircuitBreaker<T>
    {
        private class CircuitClosedState : ICircuitState
        {
            private readonly CircuitBreaker<T> _circuitBreaker;

            public CircuitClosedState(CircuitBreaker<T> circuitBreaker)
            {
                _circuitBreaker = circuitBreaker ?? throw new ArgumentNullException(nameof(circuitBreaker));
            }

            public bool IsOpen => false;

            public void Fail(T result, Exception error)
            {
                _circuitBreaker.Set(result, error);
                if (++_circuitBreaker._consecutiveFailures >= _circuitBreaker._threshold)
                {
                    _circuitBreaker.Open();
                    _circuitBreaker.SetBreakTill();
                }
            }

            public void Success()
            {
                _circuitBreaker.ResetConsecutiveFailures();
            }
        }
    }
}
