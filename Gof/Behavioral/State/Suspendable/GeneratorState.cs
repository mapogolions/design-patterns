using System;
using System.Collections.Generic;

namespace Gof.Behavioral.State.Suspendable
{
    internal abstract class GeneratorState<T>
    {
        protected readonly Generator<T> Generator;

        public GeneratorState(Generator<T> generator)
        {
            Generator = generator;
        }

        internal virtual void Suspend() => throw new NotImplementedException();
        internal virtual void Resume() => throw new NotImplementedException();
        internal virtual T Yield(IEnumerator<T> enumerator) => throw new NotImplementedException();
    }
}
