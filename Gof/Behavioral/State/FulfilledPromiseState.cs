namespace Gof.Behavioral.State
{
    internal class FulfilledPromiseState<T> : IPromiseState<T>
    {
        private readonly Promise<T> _promise;

        internal FulfilledPromiseState(Promise<T> promise) => _promise = promise;

        // A Promise can only be settled once and then stays settled
        public Promise<T> Resolve(T value) => _promise;
        public Promise<T> Reject(string error) => _promise;
    }
}
