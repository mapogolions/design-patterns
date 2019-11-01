namespace Gof.Behavioral.Strategy
{
    public class PersonEmptyStringValidator : IEntityValidator<Person>
    {
        public bool Validate(Person entity)
        {
            if (entity.FirstName is "" || entity.LastName is "")
                return false;
            return true;
        }
    }
}
