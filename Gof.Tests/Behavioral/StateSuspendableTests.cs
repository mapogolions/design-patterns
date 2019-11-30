using Gof.Behavioral.State.Suspendable;
using System;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class StateSuspendableTests
    {
        [Fact]
        public void ShouldThrowIndexOutOfRangeExceptionWhenGeneratorIsExhausted()
        {
            var generator = new Generator<string>();
            generator.Resume();
            Assert.Throws<IndexOutOfRangeException>(() => generator.Yield);
        }

        [Fact]
        public void ShouldThrowInvalidOperationExceptionWhenGeneratorIsSuspendedAndExhaused()
        {
            var generator = new Generator<int>();
            Assert.Throws<InvalidOperationException>(() => generator.Yield);
        }

        [Fact]
        public void ShouldReturnValueWhenGeneratorIsResumed()
        {
            var generator = new Generator<int>(1, 2, 3);
            generator.Resume();
            Assert.Equal(1, generator.Yield);
        }

        [Fact]
        public void ShouldThrowInvalidOperationExceptionWhenGeneratorIsSuspended()
        {
            var generator = new Generator<int>(-2, -1, 0, 1, 2, 3);
            Assert.Throws<InvalidOperationException>(() => generator.Yield);
        }
    }
}
