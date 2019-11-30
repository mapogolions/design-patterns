using System.Collections.Generic;

namespace Gof.Behavioral.State.Suspendable
{
    internal class Resumed<T> : ISuspendableMode<T>
    {
        private readonly Generator<T> _generator;
        public Resumed(Generator<T> generator) => _generator = generator;

        public void Resume() { /* do nothing */ }
        public void Suspend() => _generator.Mode = _generator.Suspended;
        public T Yield(IEnumerator<T> enumerator)
        {
            if (enumerator.MoveNext())
                return enumerator.Current;
            _generator.Mode = _generator.Exhausted;
            return _generator.Yield;
        }
    }
}
