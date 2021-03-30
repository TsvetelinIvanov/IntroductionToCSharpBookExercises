namespace _01School
{
    public class Student : Person
    {        
        private int id;

        public Student(string name, int studentId) : base(name)
        {            
            this.id = studentId;
        }

        public override string ToString()
        {
            return $"Sudent Name: {this.Name}, Student Id: {this.id}";
        }
    }
}