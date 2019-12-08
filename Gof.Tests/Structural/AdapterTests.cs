using System;
using Gof.Structural.Adapter;
using Xunit;

namespace Gof.Tests.Structural
{
    public class AdapterTests
    {
        // Test adapter pattern
        [Fact]
        public void JdkIterableProtocolShouldBeCompatibleWithForEach()
        {
            var iterable = PersistentList.Of<bool>(true, true);
            foreach (var item in new IterableAdapter<bool>(iterable))
            {
                Assert.True(item);
            }
        }

        [Fact]
        public void DotNetEnumeratorShouldYieldAllItems()
        {
            var enumerator = new IterableAdapter<int>(PersistentList.Of<int>(5, 6)).GetEnumerator();
            Assert.True(enumerator.MoveNext());
            Assert.Equal(5, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(6, enumerator.Current);
            Assert.False(enumerator.MoveNext());
            Assert.Equal(6, enumerator.Current);
        }

        [Fact]
        public void JdkIteratorShouldYieldAllItems()
        {
            var iterator = PersistentList.Of<int>(5, 6).Iterator();
            Assert.Equal(5, iterator.Next());
            Assert.Equal(6, iterator.Next());
            Assert.Throws<IndexOutOfRangeException>(() => iterator.Next());
        }

        [Fact]
        public void DotNetEnumeratorShouldReturnDefaultValueOfTypeWhenCollectionIsEmpty()
        {
            var enumerator = new IterableAdapter<bool>(PersistentList.Of<bool>()).GetEnumerator();
            Assert.Equal(default(bool), enumerator.Current);
        }

        [Fact]
        public void JdkIteratorShouldThrowIndexOutOfRangeExceptionWhenCollectionIsEmpty()
        {
            var iterator = PersistentList.Of<bool>().Iterator();
            Assert.Throws<IndexOutOfRangeException>(() => iterator.Next());
        }

        [Fact]
        public void DotNetEnumeratorShouldReturnFirstElementAfterMove()
        {
            var enumerator = new IterableAdapter<int>(PersistentList.Of<int>(2, 4)).GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(2, enumerator.Current);
        }

        [Fact]
        public void DotNetEnumeratorShouldReturnDefaultValueOfTypeInsteadOfFirstElement()
        {
            var enumerator = new IterableAdapter<int>(PersistentList.Of<int>(2, 4)).GetEnumerator();
            Assert.Equal(default(int), enumerator.Current);
        }

        [Fact]
        public void JdkIteratorShouldReturnFirstElement()
        {
            var iterator = PersistentList.Of<int>(2, 4).Iterator();
            Assert.Equal(2, iterator.Next());
        }

        // Test infrastructure
        [Fact]
        public void ShouldThrowInvalidOperationExceptionWhenCollectionIsEqualNil()
        {
            var nil = PersistentList.Of<int>();
            Assert.Throws<InvalidOperationException>(() => nil.Head);
            Assert.Throws<InvalidOperationException>(() => nil.Tail);
        }

        [Fact]
        public void ShouldReturnNilWhenCollectionIsEmpty()
        {
            Assert.Equal(Nil.New<char>(), PersistentList.Of<char>());
            Assert.Equal(Nil.New<string>(), PersistentList.Of<string>());
        }

        [Fact]
        public void ShouldCreatePersistentListWithTwoElements()
        {
            var items = new Cons<int>(8, new Cons<int>(6, Nil.New<int>()));
            Assert.Equal(8, items.Head);
            Assert.Equal(6, items.Tail.Head);
            Assert.Equal(Nil.New<int>(), items.Tail.Tail);
        }

        [Fact]
        public void ShouldCreatePersistentListWithOneElement()
        {
            var items = new Cons<int>(6, Nil.New<int>());
            Assert.Equal(6, items.Head);
            Assert.Equal(Nil.New<int>(), items.Tail);
        }
    }
}
