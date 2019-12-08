using System;
using Gof.Structural.Adapter;
using Xunit;

namespace Gof.Tests.Structural
{
    public class AdapterTests
    {
        // Test adapter pattern
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
        public void ShouldThrowInvalidOperationException()
        {
            var items = PersistentList.Of<int>();
            Assert.Throws<InvalidOperationException>(() => items.Head);
            Assert.Throws<InvalidOperationException>(() => items.Tail);
        }

        [Fact]
        public void ShouldReturnNilWhenCollectionIsEmpty()
        {
            Assert.Equal(Nil.New<char>(), PersistentList.Of<char>());
            Assert.Equal(Nil.New<string>(), PersistentList.Of<string>());
        }


        [Fact]
        public void ShouldCreatePersistentList()
        {
            var items = PersistentList.Of<int>(1, 2, 3);
            Assert.Equal(1, items.Head);
            Assert.Equal(2, items.Tail.Head);
            Assert.Equal(3, items.Tail.Tail.Head);
            Assert.IsType<Nil<int>>(items.Tail.Tail.Tail);
        }

        [Fact]
        public void ShouldCreatePersistentLinkedListWithTwoElements()
        {
            var items = new Cons<int>(8, new Cons<int>(6, Nil.New<int>()));
            Assert.Equal(8, items.Head);
            Assert.Equal(6, items.Tail.Head);
            Assert.Equal(Nil.New<int>(), items.Tail.Tail);
        }

        [Fact]
        public void ShouldCreatePersistentLinkedListWithOneElement()
        {
            var items = new Cons<int>(6, Nil.New<int>());
            Assert.Equal(6, items.Head);
            Assert.Equal(Nil.New<int>(), items.Tail);
        }
    }
}
