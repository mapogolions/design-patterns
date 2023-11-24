namespace Gof.Behavioral.State.Suspendable;

public partial class Generator<T>
{
    private class ResumedState : GeneratorState
    {
        internal ResumedState(Generator<T> generator) : base(generator)
        {
        }

        public override void Resume()
        {
            /* do nothing */
        }

        public override void Suspend()
        {
            Generator._currentState = Generator._suspendedState;
        }

        public override T Yield(IEnumerator<T> enumerator)
        {
            if (enumerator.MoveNext())
                return enumerator.Current;
            Generator._currentState = Generator._exhaustedState;
            return Generator.Yield;
        }
    }
}
