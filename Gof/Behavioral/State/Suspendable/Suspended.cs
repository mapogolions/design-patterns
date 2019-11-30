using System;
using System.Collections.Generic;

namespace Gof.Behavioral.State.Suspendable
{
    internal class Suspened<T> : ISuspendableMode<T>
    {
        private readonly Generator<T> _generator;
        public Suspened(Generator<T> generator) => _generator = generator;

        public void Resume() => _generator.Mode = _generator.Resumed;
        public void Suspend() { /* do nothing */ }
        public T Yield(IEnumerator<T> enumerator) => throw new InvalidOperationException();
    }
}
