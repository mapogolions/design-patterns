namespace Gof.Behavioral.TemplateMethod;

public class TakeTimeJob(TimeSpan takeTime) : BackgroundJob
{
    private readonly TimeSpan _takeTime = takeTime;

    protected override async Task ExecuteAsync(CancellationToken token = default)
    {
        await Task.Delay(_takeTime, token);
    }
}

public class EndlessWaitingJob : TakeTimeJob
{
    public EndlessWaitingJob() : base(Timeout.InfiniteTimeSpan) { }
}

public class CompletedAtStartTimeJob : BackgroundJob
{
    protected override Task ExecuteAsync(CancellationToken token = default)
    {
        return Task.CompletedTask;
    }
}

public class NonCancellableJob(TimeSpan takeTime) : TakeTimeJob(takeTime)
{
    protected override Task ExecuteAsync(CancellationToken token = default)
    {
        return base.ExecuteAsync(default);
    }
}
