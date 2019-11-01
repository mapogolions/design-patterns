namespace Gof.Behavioral.Strategy
{
    public class FakeClient
    {
        private readonly IPersonValidator _personValidator;

        public FakeClient(IPersonValidator personValidator) =>
            _personValidator = personValidator;

        public bool Validate(Person someone) => _personValidator.Validate(someone);
    }
}
