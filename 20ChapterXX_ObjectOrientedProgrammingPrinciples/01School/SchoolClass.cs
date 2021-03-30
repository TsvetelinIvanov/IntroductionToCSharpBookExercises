using System.Collections.Generic;

namespace _01School
{
    public class SchoolClass
    {
        private string id;
        private List<Student> students;
        private List<Teacher> teachers;

        public SchoolClass(string id)
        {
            this.id = id;
            this.students = new List<Student>();
            this.teachers = new List<Teacher>();
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public string ShowStudents()
        {
            return string.Join("; ", students);
        }

        public string ShowTeachers()
        {
            return string.Join("; ", teachers);
        }

        public override string ToString()
        {
            return $"Class: {this.id} with students: {this.ShowStudents()} and teachers: {this.ShowTeachers()}";
        }
    }
}