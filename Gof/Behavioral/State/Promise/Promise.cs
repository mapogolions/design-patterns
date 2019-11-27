namespace Gof.Behavioral.State.Promise
{
    public class Promise<T>
    {
        internal IPromiseState<T> State { get; set; }
        public T ResolvedValue { get; internal set; }
        public string Reason { get; internal set; }

        public Promise()
        {
            State = new PendingPromiseState<T>(this);
        }

        public Promise<T> Resolve(T value) => State.Resolve(value);
        public Promise<T> Reject(string error) => State.Reject(error);

        public static Promise<TValue> Resolve<TValue>(TValue value) => new Promise<TValue>().Resolve(value);
        public static Promise<TValue> Reject<TValue>(string reason) => new Promise<TValue>().Reject(reason);
    }
}
