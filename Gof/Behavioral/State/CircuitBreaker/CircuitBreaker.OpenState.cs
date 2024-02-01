
namespace Gof.Behavioral.State.CircuitBreaker
{
    public partial class CircuitBreaker<T>
    {
        private class CircuitOpenState : ICircuitState
        {
            private readonly CircuitBreaker<T> _circuitBreaker;

            public CircuitOpenState(CircuitBreaker<T> circuitBreaker)
            {
                _circuitBreaker = circuitBreaker ?? throw new ArgumentNullException(nameof(circuitBreaker));
            }

            public bool IsOpen
            {
                get
                {
                    if (_circuitBreaker._breakTill <= _circuitBreaker._clock.UtcNow)
                    {
                        _circuitBreaker.HalfOpen();
                        return false;
                    }
                    return true;
                }
            }

            public void Fail(T result, Exception error)
            {
                _circuitBreaker.Set(result, error);
            }

            public void Success()
            {
                // do nothing
            }
        }
    }
}
