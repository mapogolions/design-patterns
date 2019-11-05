using System.Collections.Generic;

namespace Gof.Creational.Builder.Trivial
{
    public class NutritionFacts
    {
        // required
        private readonly int _servingSize;
        private readonly int _servings;
        // optional
        private readonly int _calories;
        private readonly int _fat;

        private NutritionFacts(InternalBuilder builder)
        {
            _servings = builder.Servings;
            _servingSize = builder.ServingSize;
            _calories = builder.Calories;
            _fat = builder.Fat;
        }

        public class InternalBuilder
        {
            // required
            protected internal int Servings { get; private set; }
            protected internal int ServingSize { get; private set; }
            // optional
            protected internal int Calories { get; private set; }
            protected internal int Fat { get; private set; }

            public InternalBuilder(int servings, int servingSize)
            {
                Servings = servings;
                ServingSize = servingSize;
            }

            public InternalBuilder WithCalories(int calories)
            {
                Calories = calories;
                return this;
            }

            public InternalBuilder WithFat(int fat)
            {
                Fat = fat;
                return this;
            }

            public NutritionFacts Build() => new NutritionFacts(this);
        }
    }
}
