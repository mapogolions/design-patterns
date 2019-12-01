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
            var generator = new Generator<bool>(true);
            generator.Resume();
            var value = generator.Yield;
            Assert.Throws<IndexOutOfRangeException>(() => generator.Yield);
        }

        [Fact]
        public void ShouldThrowIndexOutOfRangeExceptionWhenGeneratorIsEmpty()
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
        public void ShouldReturnAllAvailableValues()
        {
            var generator = new Generator<char>('a', 'b');
            generator.Resume();
            Assert.Equal('a', generator.Yield);
            Assert.Equal('b', generator.Yield);
        }

        [Fact]
        public void ShouldReturnValueWhenGeneratorIsResumed()
        {
            var generator = new Generator<int>(1, 2, 3);
            generator.Resume();
            Assert.Equal(1, generator.Yield);
        }

        [Fact]
        public void ShouldThrowInvalidOperationExceptionWhenGeneratorIsSuspendedManually()
        {
            var generator = new Generator<char>('a', 'b', 'c');
            generator.Resume();
            generator.Suspend();
            Assert.Throws<InvalidOperationException>(() => generator.Yield);
        }

        [Fact]
        public void ShouldThrowInvalidOperationExceptionWhenGeneratorIsSuspendedByDefault()
        {
            var generator = new Generator<int>(-2, -1, 0, 1, 2, 3);
            Assert.Throws<InvalidOperationException>(() => generator.Yield);
        }
    }
}
