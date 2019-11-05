using Gof.Creational.Builder.Trivial;
using Xunit;

namespace Gof.Tests.Creational.Builder
{
    public class TrivialNutritionFactsTests
    {
        [Theory]
        [InlineData(2, 30)]
        [InlineData(2, 40)]
        public void ShoudInitializeRequiredParameters(int servings, int servingSize)
        {
            var nutritionFacts = new NutritionFacts
                .Ctor(servings, servingSize)
                .Build();
            var expected = $"{servings}|{servingSize}|{0}|{0}";
            Assert.Equal(expected, nutritionFacts.Dump);
        }

        [Theory]
        [InlineData(2, 30, 1200)]
        [InlineData(2, 40, 1200)]
        public void ShoudReturnNutritionFactsWithCalories(int servings, int servingSize, int calories)
        {
            var nutritionFacts = new NutritionFacts
                .Ctor(servings, servingSize)
                .WithCalories(calories)
                .Build();
            var expected = $"{servings}|{servingSize}|{calories}|{0}";
            Assert.Equal(expected, nutritionFacts.Dump);
        }

        [Theory]
        [InlineData(2, 30, 1200)]
        [InlineData(2, 40, 1200)]
        public void ShoudReturnNutritionFactsWithFats(int servings, int servingSize, int fats)
        {
            var nutritionFacts = new NutritionFacts
                .Ctor(servings, servingSize)
                .WithFats(fats)
                .Build();
            var expected = $"{servings}|{servingSize}|{0}|{fats}";
            Assert.Equal(expected, nutritionFacts.Dump);
        }

        [Theory]
        [InlineData(2, 30, 300, 1200)]
        [InlineData(2, 40, 400, 1200)]
        public void ShoudReturnNutritionFactsWithFatsAndCalories(int servings, int servingSize, int fats, int calories)
        {
            var nutritionFacts = new NutritionFacts
                .Ctor(servings, servingSize)
                .WithFats(fats)
                .WithCalories(calories)
                .Build();
            var expected = $"{servings}|{servingSize}|{calories}|{fats}";
            Assert.Equal(expected, nutritionFacts.Dump);
        }
    }
}
