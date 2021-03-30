namespace _02Human
{
    public class Student : Human
    {
        private double grade;

        public Student(string personalName, string familyName, double grade) : base(personalName, familyName)
        {
            this.grade = grade;
        }

        public double Grade => this.grade;

        public override string ToString()
        {
            return base.ToString() + $" Grade: {this.grade:f2}.";
        }
    }
}