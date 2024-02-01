using Gof.Behavioral.State.Promise;

namespace Gof.Tests.Behavioral.State;

public class PromiseTests
{
    [Fact]
    public void PromiseCanOnlyBeFulfilledOnce()
    {
        var promise = new Promise<bool>();
        promise.Resolve(true);
        Assert.True(promise.Result);
        Assert.Null(promise.Failure);
        var ex = Assert.Throws<InvalidOperationException>(() => promise.Resolve(false));
        Assert.Equal("Promise fulfilled. Promise(True)", ex.Message);
    }

    [Fact]
    public void PromiseCanOnlyBeRejectedOnce()
    {
        var promise = new Promise<string>();
        promise.Reject(new InvalidDataException("error 1"));
        Assert.Null(promise.Result);
        Assert.IsType<InvalidDataException>(promise.Failure);
        var ex = Assert.Throws<InvalidOperationException>(() => promise.Reject(new Exception("error 2")));
        Assert.Equal("Promise rejected", ex.Message);
    }
}
