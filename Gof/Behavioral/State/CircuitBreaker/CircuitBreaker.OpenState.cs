
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
                    _circuitBreaker._state = _circuitBreaker._halfOpenState;
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
