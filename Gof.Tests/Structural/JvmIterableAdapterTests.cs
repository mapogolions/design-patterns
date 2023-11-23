using Gof.Structural.Adapter.JvmIterable;

namespace Gof.Tests.Structural;

public class JvmIterableAdapterTests
{
    [Fact]
    public void ShouldBeCompatibleWithForEachProtocol()
    {
        var source = new[] { 1 };
        var iterable = new EnumerableAdapter<int>(source);
        foreach (var item in new IterableAdapter<int>(iterable))
        {
            Assert.Equal(1, item);
        }
    }

    [Fact]
    public void ShouldNotMoveInnerPointer()
    {
        var iterable = new EnumerableAdapter<int>(new[] { 1, 2 });
        var iterator = iterable.Iterator();

        iterator.HasNext();
        iterator.HasNext();

        Assert.Equal(1, iterator.Next());
    }

    [Fact]
    public void ShouldYeildAllValues()
    {
        var iterable = new EnumerableAdapter<string>(new[] { "foo", "bar" });
        var iterator = iterable.Iterator();
        Assert.Equal("foo", iterator.Next());
        Assert.Equal("bar", iterator.Next());
        Assert.Throws<NoSuchElementException>(() => iterator.Next());
    }

    [Fact]
    public void NextShouldThrowExceptionWhenCollectionIsEmpty()
    {
        var iterable = new EnumerableAdapter<int>(new int[0]);
        var iterator = iterable.Iterator();
        Assert.Throws<NoSuchElementException>(() => iterator.Next());
    }

    [Fact]
    public void HasNextShouldReturnFalseWhenCollectionIsEmpty()
    {
        var iterable = new EnumerableAdapter<int>(new int[0]);
        var iterator = iterable.Iterator();
        Assert.False(iterator.HasNext());
    }
}
