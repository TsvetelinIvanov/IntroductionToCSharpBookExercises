using System.Collections.Generic;

namespace _22School
{
    public class Teacher
    {
        private string name;
        private List<Discipline> disciplines = new List<Discipline>();

        public Teacher(string name)
        {
            this.name = name;
            this.disciplines = new List<Discipline>();
        }
        
        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public override string ToString()
        {            
            return $"Teacher Name: {this.name}, Disciplines: {string.Join(", ", this.disciplines)}";
        }        
    }
}