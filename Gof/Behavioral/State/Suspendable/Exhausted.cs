using System;
using System.Collections.Generic;

namespace Gof.Behavioral.State.Suspendable
{
    internal class Exhausted<T> : ISuspendableMode<T>
    {
        private readonly Generator<T> _generator;
        public Exhausted(Generator<T> generator) => _generator = generator;

        public void Resume() => throw new InvalidOperationException();
        public void Suspend() => throw new InvalidOperationException();
        public T Yield(IEnumerator<T> enumerator) => throw new IndexOutOfRangeException();
    }
}
