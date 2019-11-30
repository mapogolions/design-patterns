using System.Collections.Generic;

namespace Gof.Behavioral.State.Suspendable
{
    internal interface ISuspendableMode<T>
    {
        void Suspend();
        void Resume();
        T Yield(IEnumerator<T> enumerator);
    }
}
