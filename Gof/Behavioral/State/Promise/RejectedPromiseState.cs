namespace Gof.Behavioral.State.Promise;

internal class RejectedPromiseState<T> : IPromiseState<T>
{
    private readonly Promise<T> _promise;

    public RejectedPromiseState(Promise<T> promise)
    {
        _promise = promise;
    }

    public Promise<T> Resolve(T value) =>
        throw new InvalidOperationException("Promise rejected");
    public Promise<T> Reject(Exception failure) =>
        throw new InvalidOperationException("Promise rejected");
}
