using System.Collections.Generic;

namespace Gof.Behavioral.State.Suspendable
{
    public class Generator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        internal ISuspendableMode<T> Mode { get; set; }
        internal ISuspendableMode<T> SuspendMode { get; set; }
        internal ISuspendableMode<T> ResumeMode { get; set; }
        internal ISuspendableMode<T> ExhaustedMode { get; set; }

        public Generator(params T[] items)
        {
            _enumerator = new List<T>(items).GetEnumerator();
            SuspendMode = new SuspendMode<T>(this);
            ResumeMode = new ResumeMode<T>(this);
            Mode = SuspendMode;
        }

        public void Suspend() => Mode.Resume();
        public void Resume() => Mode.Resume();

        public T Yield() => Mode.Yield(_enumerator);
    }
}
