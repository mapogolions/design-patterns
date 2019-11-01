namespace Gof.Behavioral.Strategy
{
    public class PersonNullableValidator : IEntityValidator<Person>
    {
        public bool Validate(Person entity)
        {
            if (entity.FirstName is null || entity.LastName is null)
                return false;
            return true;
        }
    }
}
