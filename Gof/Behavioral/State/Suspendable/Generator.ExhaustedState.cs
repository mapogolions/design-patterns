namespace Gof.Behavioral.State.Suspendable;

public partial class Generator<T>
{
    private class ExhaustedState : GeneratorState
    {
        public ExhaustedState(Generator<T> generator) : base(generator)
        {
        }

        public override T Yield(IEnumerator<T> enumerator) => throw new IndexOutOfRangeException();
    }
}
