using Gof.Behavioral.State.Promise;

namespace Gof.Tests.Behavioral;

public class StatePromiseTests
{
    [Fact]
    public void PromiseCanOnlyBeFulfilledOnce()
    {
        var promise = new Promise<bool>();
        promise
            .Resolve(true)
            .Resolve(false);
        Assert.True(promise.ResolvedValue);
    }

    [Fact]
    public void PromiseCanOnlyBeRejectedOnce()
    {
        var promise = new Promise<bool>();
        promise
            .Reject("first error")
            .Reject("second error");
        Assert.Equal("first error", promise.Reason);
    }
}
