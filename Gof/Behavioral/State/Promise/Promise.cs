namespace Gof.Behavioral.State.Promise;

public class Promise<T>
{
    internal IPromiseState<T> State { get; set; }
    public T? Result { get; internal set; }
    public Exception? Failure { get; internal set; }

    public Promise() => State = new PendingPromiseState<T>(this);

    public Promise<T> Resolve(T value) => State.Resolve(value);
    public Promise<T> Reject(Exception failure) => State.Reject(failure);
}
