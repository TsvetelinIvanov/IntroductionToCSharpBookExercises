using System;
using System.Collections.Generic;
using System.Text;

namespace _22School
{
    public class SchoolTest
    {
        private School school = new School("Peter Parchevich");
        private SchoolClass class7A = new SchoolClass("VII A");
        private SchoolClass class7B = new SchoolClass("VII B");        
        private Student student1 = new Student("Vanja Ivanova", 1);
        private Student student2 = new Student("Ivan Ivanov", 2);
        private Student student3 = new Student("Petar Ivanov", 3);
        private Student student4 = new Student("Petar Petrov", 4);
        private Student student5 = new Student("Angel Petrov", 1);
        private Student student6 = new Student("Petya Petrova", 2);
        private Teacher teacher1 = new Teacher("Georg Ivanov");
        private Teacher teacher2 = new Teacher("Gergana Ivanova");
        private Discipline discipline1 = new Discipline("History", 60, 60);
        private Discipline discipline2 = new Discipline("Biology", 60, 60);
        private Discipline discipline3 = new Discipline("Physics", 60, 60);
        private Discipline discipline4 = new Discipline("Chemistry", 60, 60);

        public string TestSchool()
        {
            this.teacher1.AddDiscipline(this.discipline1);
            this.teacher1.AddDiscipline(this.discipline2);
            this.teacher2.AddDiscipline(this.discipline3);
            this.teacher2.AddDiscipline(this.discipline4);
            this.class7A.AddTeacher(this.teacher1);
            this.class7A.AddTeacher(this.teacher2);
            this.class7A.AddStudent(this.student1);
            this.class7A.AddStudent(this.student2);
            this.class7A.AddStudent(this.student3);
            this.class7A.AddStudent(this.student4);
            this.class7B.AddTeacher(this.teacher1);
            this.class7B.AddTeacher(this.teacher2);
            this.class7B.AddStudent(this.student5);
            this.class7B.AddStudent(this.student6);
            this.school.AddClass(this.class7A);
            this.school.AddClass(this.class7B);

            return this.school.ToString();
        }
    }
}
