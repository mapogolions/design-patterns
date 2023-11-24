namespace Gof.Behavioral.State.Promise;

internal class FulfilledPromiseState<T> : IPromiseState<T>
{
    private readonly Promise<T> _promise;

    internal FulfilledPromiseState(Promise<T> promise) => _promise = promise;

    // A Promise can only be settled once and then stays settled
    public Promise<T> Resolve(T value) => 
        throw new InvalidOperationException($"Promise fulfilled. Promise({_promise.Result})");
    public Promise<T> Reject(Exception failure) =>
        throw new InvalidOperationException($"Promise fulfilled. Promise({_promise.Result})");
}
