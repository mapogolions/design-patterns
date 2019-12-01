using System;
using Gof.Structural.Decorator.Scalar;
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
        public void LogicAndShouldReturnTrueWhenAllConditionsAreTrue()
        {
            Assert.True(new And(new True(), new True()).Value);
        }

        [Fact]
        public void LogicAndShouldReturnFalseWhenAtLeastOneConditionIsFalse()
        {
            Assert.False(new And(new True(), new False()).Value);
        }

        [Fact]
        public void LogicOrShouldReturnTrueWhenAtLeastOneConditionIsTrue()
        {
            Assert.True(new Or(new False(), new True()).Value);
        }

        [Fact]
        public void LogicOrShouldReturnFalseWhenAllConditionsAreFalse()
        {
            Assert.False(new Or(new False(), new False()).Value);
        }

        [Fact]
        public void LogicOrShouldThrowExceptionWhenPrimitiveIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new NoNull<bool>(null).Value);
        }
    }
}
