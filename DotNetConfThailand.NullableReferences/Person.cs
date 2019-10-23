namespace DotNetConfThailand.NullableReferences
{
    public class Person
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Person(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
    }
}
