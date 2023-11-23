namespace Gof.Behavioral.State.Suspendable;

internal class SuspendedState<T> : GeneratorState<T>
{
    internal SuspendedState(Generator<T> generator) : base(generator) { }

    internal override void Resume()
    {
        Generator.CurrentState = Generator.ResumedState;
    }

    internal override void Suspend() { /* do nothing */ }

    internal override T Yield(IEnumerator<T> enumerator) => throw new InvalidOperationException();
}
