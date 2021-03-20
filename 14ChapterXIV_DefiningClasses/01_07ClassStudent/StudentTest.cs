using System;
using System.Text;

namespace _01_07ClassStudent
{
    public class StudentTest
    {
        private const string FirstName = "Ivan";
        private const string MiddleName = "Ivanov";
        private const string LastName = "Ivanov";
        private const int Course = 1;
        private const string Speciality = "C#";
        private const string University = "SoftUni";
        private const string Email = "ivan@abv.bg";
        private const string PhoneNumber = "0999 99 99 99";

        public static string TestStudent()
        {            
            Student fullStudent = new Student(FirstName, MiddleName, LastName, Course, Speciality, University, Email, PhoneNumber);
            Student minStudent = new Student(FirstName, LastName, University);
            Student withoutContactsStudent = new Student(FirstName, MiddleName, LastName, Course, Speciality, University);

            StringBuilder testStudentBuilder = new StringBuilder();
            testStudentBuilder.AppendLine($"Full Student -> {Environment.NewLine}{fullStudent.ShowStudentInfo()}{Environment.NewLine}");            
            testStudentBuilder.AppendLine($"Min Student -> {Environment.NewLine}{minStudent.ShowStudentInfo()}{Environment.NewLine}");
            testStudentBuilder.Append($"Student without contacts -> {Environment.NewLine}{withoutContactsStudent.ShowStudentInfo()}");

            return testStudentBuilder.ToString();
        }
    }
}
