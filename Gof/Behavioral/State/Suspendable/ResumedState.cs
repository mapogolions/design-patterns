namespace Gof.Behavioral.State.Suspendable;

internal class ResumedState<T> : GeneratorState<T>
{
    internal ResumedState(Generator<T> generator) : base(generator) { }

    internal override void Resume() { /* do nothing */ }

    internal override void Suspend()
    {
        Generator.CurrentState = Generator.SuspendedState;
    }

    internal override T Yield(IEnumerator<T> enumerator)
    {
        if (enumerator.MoveNext())
            return enumerator.Current;
        Generator.CurrentState = Generator.ExhaustedState;
        return Generator.Yield;
    }
}
