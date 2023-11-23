namespace Gof.Behavioral.State.Suspendable;
public class Generator<T>
{
    private readonly IEnumerator<T> _items;

    public Generator(params T[] items)
    {
        _items = new List<T>(items).GetEnumerator();
        SuspendedState = new SuspendedState<T>(this);
        ResumedState = new ResumedState<T>(this);
        ExhaustedState = new ExhaustedState<T>(this);
        CurrentState = ResumedState;
    }

    public Generator() : this([]) { }

    internal GeneratorState<T> CurrentState { get; set; }
    internal SuspendedState<T> SuspendedState { get; }
    internal ResumedState<T> ResumedState { get; }
    internal ExhaustedState<T> ExhaustedState { get; }

    public void Suspend() => CurrentState.Suspend();
    public void Resume() => CurrentState.Resume();
    public T Yield => CurrentState.Yield(_items);
}
