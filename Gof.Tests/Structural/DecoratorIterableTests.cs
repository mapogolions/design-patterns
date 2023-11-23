using Gof.Structural.Decorator.Iterable;

namespace Gof.Tests.Structural;

public class DecoratorIterableTests
{
    [Fact]
    public void ShouldReturnFirstElementWithIndex()
    {
        var enumerator = new List<char>() { 'a', 'b', 'c' }.GetEnumerator().WithIndex();

        enumerator.MoveNext();
        var first = enumerator.Current;

        Assert.Equal('a', first.Value);
        Assert.Equal(0, first.Index);
    }
}
