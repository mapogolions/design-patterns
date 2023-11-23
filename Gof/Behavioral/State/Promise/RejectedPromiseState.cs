namespace Gof.Behavioral.State.Promise;

internal class RejectedPromiseState<T>(Promise<T> promise) : IPromiseState<T>
{
    private readonly Promise<T> _promise = promise;

    public Promise<T> Resolve(T value) => _promise;
    public Promise<T> Reject(string error) => _promise;
}
