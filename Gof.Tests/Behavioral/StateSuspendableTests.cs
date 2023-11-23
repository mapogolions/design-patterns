using Gof.Behavioral.State.Suspendable;

namespace Gof.Tests.Behavioral;

public class StateSuspendableTests
{
    [Fact]
    public void ShouldThrowIndexOutOfRangeExceptionWhenGeneratorIsExhausted()
    {
        var generator = new Generator<bool>(true);
        var value = generator.Yield;
        Assert.Throws<IndexOutOfRangeException>(() => generator.Yield);
    }

    [Fact]
    public void ShouldThrowIndexOutOfRangeExceptionWhenGeneratorIsEmpty()
    {
        var generator = new Generator<string>();
        Assert.Throws<IndexOutOfRangeException>(() => generator.Yield);
    }

    [Fact]
    public void ShouldReturnAllAvailableValuesInProperSequence()
    {
        var generator = new Generator<char>('a', 'b');
        Assert.Equal('a', generator.Yield);
        Assert.Equal('b', generator.Yield);
        Assert.Throws<IndexOutOfRangeException>(() => generator.Yield);
    }

    [Fact]
    public void ShouldThrowInvalidOperationExceptionWhenGeneratorIsSuspendedManually()
    {
        var generator = new Generator<char>('a', 'b', 'c');
        generator.Suspend();
        Assert.Throws<InvalidOperationException>(() => generator.Yield);
    }

    [Fact]
    public void ShouldResumedByDefault()
    {
        var generator = new Generator<int>(-2, -1, 0, 1, 2, 3);
        Assert.Equal(-2, generator.Yield);
    }
}
