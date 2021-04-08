namespace _04StudentsByAgeRange
{
    public class Student
    {
        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public int Age { get; }
    }
}