namespace Gof.Behavioral.State
{
    internal class FulfilledPromiseState<T> : IPromiseState<T>
    {
        private readonly Promise<T> _promise;

        internal FulfilledPromiseState(Promise<T> promise) => _promise = promise;

        public Promise<T> Resolve(T value) => _promise;
        public Promise<T> Reject(string error) => _promise;
    }
}
