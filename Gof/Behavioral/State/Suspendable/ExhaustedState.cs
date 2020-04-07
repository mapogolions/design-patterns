using System;
using System.Collections.Generic;

namespace Gof.Behavioral.State.Suspendable
{
    internal class ExhaustedState<T> : GeneratorState<T>
    {
        internal ExhaustedState(Generator<T> generator) : base(generator) { }

        internal override T Yield(IEnumerator<T> enumerator) => throw new IndexOutOfRangeException();
    }
}
