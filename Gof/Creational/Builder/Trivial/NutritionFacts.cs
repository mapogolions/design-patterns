namespace Gof.Creational.Builder.Trivial
{
    public class NutritionFacts
    {
        // required
        private readonly int _servings;
        private readonly int _servingSize;
        // optional
        private readonly int _calories;
        private readonly int _fats;

        private NutritionFacts(Ctor builder)
        {
            _servings = builder.Servings;
            _servingSize = builder.ServingSize;
            _calories = builder.Calories;
            _fats = builder.Fats;
        }

        public string Dump => $"{_servings}|{_servingSize}|{_calories}|{_fats}";

        public class Ctor
        {
            // required
            protected internal int Servings { get; private set; }
            protected internal int ServingSize { get; private set; }
            // optional
            protected internal int Calories { get; private set; }
            protected internal int Fats { get; private set; }

            public Ctor(int servings, int servingSize)
            {
                Servings = servings;
                ServingSize = servingSize;
            }

            public Ctor WithCalories(int calories)
            {
                Calories = calories;
                return this;
            }

            public Ctor WithFats(int fats)
            {
                Fats = fats;
                return this;
            }

            public NutritionFacts Build() => new NutritionFacts(this);
        }
    }
}
