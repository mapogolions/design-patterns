namespace Gof.Behavioral.State.Suspendable;

public partial class Generator<T>
{
    private readonly IEnumerator<T> _items;

    public Generator(params T[] items)
    {
        _items = new List<T>(items).GetEnumerator();
        // Cache all possible states
        // This prevents multiple instances of the same state from being created when switching.
        _suspendedState = new SuspendedState(this);
        _resumedState = new ResumedState(this);
        _exhaustedState = new ExhaustedState(this);
        _currentState = _resumedState;
    }

    public Generator() : this(Array.Empty<T>()) { }
    public void Suspend() => _currentState.Suspend();
    public void Resume() => _currentState.Resume();
    public T Yield => _currentState.Yield(_items);

    private GeneratorState _currentState;
    private readonly SuspendedState _suspendedState;
    private readonly ResumedState _resumedState;
    private readonly ExhaustedState _exhaustedState;
}
