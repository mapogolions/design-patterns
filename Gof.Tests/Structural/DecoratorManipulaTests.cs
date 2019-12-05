using System;
using System.Linq;
using System.Collections.Generic;
using Gof.Structural.Decorator.Manipula;
using Xunit;

namespace Gof.Tests.Structural
{
    public class DecoratorManipulaTests
    {
        [Fact]
        public void ShouldTakeOnlyFirstElement()
        {
            var origin = new List<char>() { 'a', 'b', 'c' };
            var embellished = new TakeEnumerable<char>(origin, 1);
            Assert.Equal('a', embellished.First());
        }

        [Fact]
        public void ShouldSkipAllItemsExceptTheFirst()
        {
            var origin = new List<char>() { 'a', 'b', 'c' };
            var embellished = new SkipLastEnumerable<char>(origin, 2);
            Assert.Equal('a', embellished.First());
        }

        [Fact]
        public void ShouldAppendItemToEmptyCollection()
        {
            var origin = new List<char>();
            var embellished = new AppendEnumerable<char>(origin, 'a');
            Assert.Throws<InvalidOperationException>(() => origin.First());
            Assert.Equal('a', embellished.First());
        }
    }
}
