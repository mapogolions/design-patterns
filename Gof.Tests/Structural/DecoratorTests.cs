using System;
using Gof.Structural.Decorator;
using Xunit;

namespace Gof.Tests.Structural
{
    public class DecoratorTests
    {
        [Fact]
        public void ShouldReturnTruePrimitive()
        {
            Assert.True(new True().Value);
        }

        [Fact]
        public void ShouldReturnFalsePrimitive()
        {
            Assert.False(new False().Value);
        }

        [Fact]
        public void LogicNotShouldInvertValue()
        {
            Assert.False(new Not(new True()).Value);
            Assert.True(new Not(new False()).Value);
        }

        [Fact]
        public void LogicAndShouldReturnTrueWhenAllConditionIsTrue()
        {
            Assert.True(new And(new True(), new True()).Value);
        }

        [Fact]
        public void LogicAndShouldReturnFalseWhenAllConditionIsFalse()
        {
            Assert.True(new And(new True(), new True()).Value);
        }

        [Fact]
        public void LogicOrShouldReturnTrueWhenAtLeastOneConditionIsTrue()
        {
            Assert.True(new Or(new False(), new True()).Value);
        }

        [Fact]
        public void LogicOrShouldReturnFalseWhenAllConditionsIsFalse()
        {
            Assert.False(new Or(new False(), new False()).Value);
        }

        [Fact]
        public void LogicOrShouldThrowExceptionWhenPrimitiveIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new NoNulls<bool>(null).Value);
        }
    }
}
