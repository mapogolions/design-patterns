namespace Gof.Behavioral.Strategy
{
    public class Person : IEntity
    {
        public readonly string _firstName;
        public readonly string _lastName;

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string FirstName => _firstName;
        public string LastName => _lastName;
    }
}
