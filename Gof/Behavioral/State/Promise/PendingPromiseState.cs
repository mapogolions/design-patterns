namespace Gof.Behavioral.State.Promise;

internal class PendingPromiseState<T> : IPromiseState<T>
{
    private readonly Promise<T> _promise;

    internal PendingPromiseState(Promise<T> promise) => _promise = promise;

    public Promise<T> Reject(Exception failure)
    {
        _promise.State = new RejectedPromiseState<T>(_promise);
        _promise.Failure = failure;
        return _promise;
    }

    public Promise<T> Resolve(T value)
    {
        _promise.State = new FulfilledPromiseState<T>(_promise);
        _promise.Result = value;
        return _promise;
    }
}
