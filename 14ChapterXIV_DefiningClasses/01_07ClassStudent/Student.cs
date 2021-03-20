using System.Text;

namespace _01_07ClassStudent
{
    public class Student
    {
        static int studentsCount = 0;
        private string firstName;
        private string middleName;
        private string lastName;
        private int course;
        private string specialty;
        private string university;
        private string email;
        private string phoneNumber;

        public Student(string firstName, string middleName, string lastName, int course, string specialty, string university, string email, string phoneNumber)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.course = course;
            this.specialty = specialty;
            this.university = university;
            this.email = email;
            this.phoneNumber = phoneNumber;
            studentsCount++;
        }        

        public Student(string firstName, string lastName, string university) : this(firstName, null, lastName, 0, null, university, null, null)
        {

        }

        public Student(string firstName, string middleName, string lastName, int course, string specialty, string university) : this(firstName, middleName, lastName, course, specialty, university, null, null)
        {

        }        

        public string ShowStudentInfo()
        {
            StringBuilder studentInfoBuilder = new StringBuilder();

            studentInfoBuilder.AppendLine("First Name: " + this.firstName);
            studentInfoBuilder.AppendLine("Middle Name: " + this.middleName);
            studentInfoBuilder.AppendLine("Last Name: " + this.lastName);
            studentInfoBuilder.AppendLine("Course: " + this.course);
            studentInfoBuilder.AppendLine("Specialty: " + this.specialty);
            studentInfoBuilder.AppendLine("University: " + this.university);
            studentInfoBuilder.AppendLine("email: " + this.email);
            studentInfoBuilder.Append("Phone Number: " + this.phoneNumber);

            return studentInfoBuilder.ToString();
        }

        public static int StudentsCount
        {
            get { return Student.studentsCount; }
            set { Student.studentsCount = value; }
        }
    }
}
