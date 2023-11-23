using Gof.Behavioral.TemplateMethod;

namespace Gof.Tests.Behavioral;

public class TemplateMethodTests
{
    [Fact]
    public void ShouldReturnExecutingTask()
    {
        var backgroundJob = new CompletedAtStartTimeJob();
        var executingTask = backgroundJob.RunAsync(new());

        Assert.True(ReferenceEquals(executingTask, backgroundJob.ExecutingTask));
        Assert.True(backgroundJob.ExecutingTask.IsCompletedSuccessfully);
        Assert.True(executingTask.IsCompletedSuccessfully);
    }

    [Fact]
    public async Task KillAsyncWaitsUntilBackgroundTaskHasBeenCompleted()
    {
        var backgroundJob = new NonCancellableJob(TimeSpan.FromMilliseconds(100));
        await backgroundJob.RunAsync(new());

        await backgroundJob.StopAsync(new());

        Assert.True(backgroundJob.ExecutingTask!.IsCompletedSuccessfully);
    }

    [Fact]
    public async Task DisposeDoesNotGuaranteeCancellationOfTheBackgroundTask()
    {
        var backgroundJob = new NonCancellableJob(TimeSpan.FromMilliseconds(10));
        await backgroundJob.RunAsync(new());

        backgroundJob.Dispose();
        Assert.False(backgroundJob.ExecutingTask!.IsCanceled);

        await Task.WhenAll(backgroundJob.ExecutingTask);
        Assert.True(backgroundJob.ExecutingTask.IsCompletedSuccessfully);
    }

    [Fact]
    public async Task KillAsyncShouldStopBackgroundTask()
    {
        var backgroundJob = new EndlessWaitingJob();
        await backgroundJob.RunAsync(new());

        Assert.False(backgroundJob.ExecutingTask!.IsCompleted);

        await backgroundJob.StopAsync(default);

        Assert.True(backgroundJob.ExecutingTask.IsCompleted);
        Assert.True(backgroundJob.ExecutingTask.IsCanceled);
    }

    [Fact]
    public async Task DisposeShouldStopBackgroundTask()
    {
        var backgroundJob = new EndlessWaitingJob();
        await backgroundJob.RunAsync(new());

        Assert.False(backgroundJob.ExecutingTask!.IsCompleted);

        backgroundJob.Dispose(); // endless wait interrupted

        await Assert.ThrowsAsync<TaskCanceledException>(async () => await backgroundJob.ExecutingTask);
        Assert.True(backgroundJob.ExecutingTask.IsCompleted);
        Assert.True(backgroundJob.ExecutingTask.IsCanceled);
    }
}
