namespace Gof.Behavioral.State.Suspendable;

public partial class Generator<T>
{
    private class SuspendedState : GeneratorState
    {
        public SuspendedState(Generator<T> generator) : base(generator)
        {
        }

        public override void Resume()
        {
            Generator._currentState = Generator._resumedState;
        }

        public override void Suspend()
        {
            /* do nothing */
        }

        public override T Yield(IEnumerator<T> enumerator) => throw new InvalidOperationException();
    }
}
