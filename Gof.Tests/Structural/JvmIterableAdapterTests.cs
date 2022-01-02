using System;
using System.Collections.Generic;
using Gof.Structural.Adapter.JvmIterable;
using Xunit;

namespace Gof.Tests.Structural
{
    public class JvmIterableAdapterTests
    {
        [Fact]
        public void ShouldYeildAllValues()
        {
            var iterable = new EnumerableAdapter<string>(new []{ "foo", "bar" });
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
}
