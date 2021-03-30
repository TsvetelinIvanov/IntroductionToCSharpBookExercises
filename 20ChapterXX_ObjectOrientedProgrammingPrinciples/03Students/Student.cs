using System;

namespace _03Students
{
    public class Student : Human, IComparable<Student>
    {
        private double grade;

        public Student(string personalName, string familyName, double grade) : base(personalName, familyName)
        {
            this.grade = grade;
        }

        public double Grade => this.grade;

        public int CompareTo(Student otherStudent)
        {
            return this.Grade.CompareTo(otherStudent.Grade);
        }

        public override string ToString()
        {
            return base.ToString() + $" Grade: {this.grade:f2}.";
        }
    }
}