using System;
using System.Collections.Generic;

namespace Gof.Behavioral.State.Suspendable
{
    internal class ExhaustedMode<T> : ISuspendableMode<T>
    {
        private readonly Generator<T> _generator;
        public ExhaustedMode(Generator<T> generator) => _generator = generator;

        public void Resume() => throw new InvalidOperationException();
        public void Suspend() => throw new InvalidOperationException();
        public T Yield(IEnumerator<T> enumerator) => throw new IndexOutOfRangeException();
    }
}
