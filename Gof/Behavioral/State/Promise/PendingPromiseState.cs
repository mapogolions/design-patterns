namespace Gof.Behavioral.State.Promise;

internal class PendingPromiseState<T> : IPromiseState<T>
{
    private readonly Promise<T> _promise;

    internal PendingPromiseState(Promise<T> promise) => _promise = promise;

    public Promise<T> Reject(string error)
    {
        _promise.Reason = error;
        _promise.State = new RejectedPromiseState<T>(_promise);
        return _promise;
    }

    public Promise<T> Resolve(T value)
    {
        _promise.ResolvedValue = value;
        _promise.State = new FulfilledPromiseState<T>(_promise);
        return _promise;
    }
}
