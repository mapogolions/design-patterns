namespace Gof.Behavioral.State.CircuitBreaker
{
    public interface ISystemClock
    {
        DateTime UtcNow { get; }
    }
}
