namespace Gof.Behavioral.State
{
    internal interface IPromiseState<T>
    {
        Promise<T> Resolve(T value);
        Promise<T> Reject(string error);
    }

    public class Promise<T>
    {
        internal IPromiseState<T> State { get; set; }
        public T ResolvedValue { get; internal set; }
        public string Error { get; internal set; }

        public Promise()
        {
            State = new PendingPromiseState<T>(this);
        }

        public Promise<T> Resolve(T value) => State.Resolve(value);
        public Promise<T> Reject(string error) => State.Reject(error);
    }

    internal class PendingPromiseState<T> : IPromiseState<T>
    {
        private readonly Promise<T> _promise;

        internal PendingPromiseState(Promise<T> promise) => _promise = promise;

        public Promise<T> Reject(string error)
        {
            if (_promise.State is PendingPromiseState<T>)
            {
                _promise.Error = error;
                _promise.State = new RejectedPromiseState<T>(_promise);
            }
            return _promise;
        }

        public Promise<T> Resolve(T value)
        {
            _promise.ResolvedValue = value;
            _promise.State = new FulfilledPromiseState<T>(_promise);
            return _promise;
        }
    }

    internal class RejectedPromiseState<T> : IPromiseState<T>
    {
        private readonly Promise<T> _promise;

        public RejectedPromiseState(Promise<T> promise) => _promise = promise;

        public Promise<T> Resolve(T value) => _promise;
        public Promise<T> Reject(string error) => _promise;
    }

    internal class FulfilledPromiseState<T> : IPromiseState<T>
    {
        private readonly Promise<T> _promise;

        internal FulfilledPromiseState(Promise<T> promise) => _promise = promise;

        public Promise<T> Resolve(T value) => _promise;
        public Promise<T> Reject(string error) => _promise;
    }
}
