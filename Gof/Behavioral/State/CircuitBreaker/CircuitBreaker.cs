namespace Gof.Behavioral.State.CircuitBreaker
{
    public partial class CircuitBreaker<T>
    {
        private T? _lastResult;
        private Exception? _lastError;
        private readonly object _lock = new();
        private DateTime _breakTill = DateTime.MinValue;
        private readonly int _threshold;
        private readonly TimeSpan _breakDuration;
        private readonly ISystemClock _clock;
        private int _consecutiveFailures;

        private ICircuitState _state;
        private readonly ICircuitState _closedState;
        private readonly ICircuitState _openState;
        private readonly ICircuitState _halfOpenState;

        public CircuitBreaker(int threshold, TimeSpan breakDuration, ISystemClock clock)
        {
            _threshold = threshold;
            _breakDuration = breakDuration;
            _clock = clock;
            _closedState = new CircuitClosedState(this);
            _openState = new CircuitOpenState(this);
            _halfOpenState = new CircuitHalfOpenState(this);
            _state = _closedState;
        }

        public bool IsOpen
        {
            get
            {
                if (_state != _openState) return false;
                lock (_lock)
                {
                    return _state.IsOpen;
                }
            }
        }

        public void Success()
        {
            lock (_lock)
            {
                _state.Success();
            }
        }

        public void Fail(T result, Exception error) 
        {
            lock ( _lock)
            {
                _state.Fail(result, error);
            }
        }

        private void SetBreakTill()
        {
            _breakTill = _clock.UtcNow.Add(_breakDuration);
        }

        private void Set(T result, Exception error)
        {
            _lastResult = result;
            _lastError = error;
        }

        private void Reset()
        {
            _lastError = null;
            _lastResult = default;
            _breakTill = DateTime.MinValue;
            this.Close();
        }

        private void Open() => _state = _openState;
        private void Close() => _state = _closedState;
        private void HalfOpen() => _state = _halfOpenState;
    }
}
