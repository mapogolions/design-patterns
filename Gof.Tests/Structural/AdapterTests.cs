using System;
using Gof.Structural.Adapter;
using Xunit;

namespace Gof.Tests.Structural
{
    public class AdapterTests
    {
        [Fact]
        public void ShouldCreatePersistentList()
        {
            var items = PersistentList.Of<int>(1, 2, 3);
            Assert.Equal(1, items.Head);
            Assert.Equal(2, items.Tail.Head);
            Assert.Equal(3, items.Tail.Tail.Head);
            Assert.Null(items.Tail.Tail.Tail);
        }
    }
}
