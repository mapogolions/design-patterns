namespace Gof.Behavioral.State.Suspendable
{
    internal abstract class GeneratorState<T>(Generator<T> generator)
    {
        protected readonly Generator<T> Generator = generator;

        internal virtual void Suspend() => throw new NotImplementedException();
        internal virtual void Resume() => throw new NotImplementedException();
        internal virtual T Yield(IEnumerator<T> enumerator) => throw new NotImplementedException();
    }
}
