using Gof.Behavioral.State;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class StateTests
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
}
