using System;
using System.Collections.Generic;

namespace Gof.Behavioral.State.Suspendable
{
    internal class SuspendMode<T> : ISuspendableMode<T>
    {
        private readonly Generator<T> _generator;
        public SuspendMode(Generator<T> generator) => _generator = generator;

        public void Resume() => _generator.Mode = _generator.ResumeMode;
        public void Suspend() { /* do nothing */ }
        public T Yield(IEnumerator<T> enumerator) => throw new InvalidOperationException();
    }
}
