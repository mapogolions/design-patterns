using System.Collections.Generic;

namespace Gof.Behavioral.State.Suspendable
{
    internal class ResumeMode<T> : ISuspendableMode<T>
    {
        private readonly Generator<T> _generator;
        public ResumeMode(Generator<T> generator) => _generator = generator;

        public void Resume() { /* do nothing */ }
        public void Suspend() => _generator.Mode = _generator.SuspendMode;
        public T Yield(IEnumerator<T> enumerator)
        {
            if (enumerator.MoveNext())
                return enumerator.Current;
            _generator.Mode = _generator.ExhaustedMode;
            return _generator.Yield;
        }
    }
}
