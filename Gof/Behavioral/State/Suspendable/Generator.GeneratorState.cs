namespace Gof.Behavioral.State.Suspendable;

public partial class Generator<T>
{
    private abstract class GeneratorState
    {
        protected readonly Generator<T> Generator;

        protected GeneratorState(Generator<T> generator)
        {
            Generator = generator;
        }

        public virtual void Suspend() => throw new InvalidOperationException();
        public virtual void Resume() => throw new InvalidOperationException();
        public virtual T Yield(IEnumerator<T> enumerator) => throw new InvalidOperationException();
    }
}
