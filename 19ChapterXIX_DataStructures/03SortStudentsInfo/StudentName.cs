using System;

namespace _03SortStudentsInfo
{
    public class StudentName : IComparable<StudentName>
    {
        private string firstName;
        private string lastName;

        public StudentName(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public int CompareTo(StudentName studentName)
        {
            int result = lastName.CompareTo(studentName.lastName);
            if (result == 0)
            {
                result = firstName.CompareTo(studentName.firstName);
            }

            return result;
        }
        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}