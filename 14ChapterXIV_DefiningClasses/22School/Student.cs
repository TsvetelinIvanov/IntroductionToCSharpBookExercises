namespace _22School
{
    public class Student
    {
        private string name;
        private int id;

        public Student(string name, int studentId)
        {
            this.name = name;
            this.id = studentId;
        }      

        public override string ToString()
        {
            return $"Sudent Name: {this.name}, Student Id: {this.id}";
        }
    }
}