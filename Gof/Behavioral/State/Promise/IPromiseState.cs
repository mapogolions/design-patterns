namespace Gof.Behavioral.State.Promise;

internal interface IPromiseState<T>
{
    Promise<T> Resolve(T value);
    Promise<T> Reject(Exception failure);
}
