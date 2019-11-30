using System;
using System.Collections.Generic;

namespace Gof.Behavioral.State.Suspendable
{
    public class Generator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        internal ISuspendableMode<T> Mode { get; set; }
        internal ISuspendableMode<T> Suspended { get; set; }
        internal ISuspendableMode<T> Resumed { get; set; }
        internal ISuspendableMode<T> Exhausted { get; set; }

        public Generator(params T[] items)
        {
            _enumerator = new List<T>(items).GetEnumerator();
            Suspended = new Suspened<T>(this);
            Resumed = new Resumed<T>(this);
            Exhausted = new Exhausted<T>(this);
            Mode = Suspended;
        }

        public Generator() : this(Array.Empty<T>()) { }

        public void Suspend() => Mode.Suspend();
        public void Resume() => Mode.Resume();
        public T Yield => Mode.Yield(_enumerator);
    }
}
