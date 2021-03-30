using System.Collections.Generic;

namespace _01School
{
    public class Teacher : Person
    {
        private List<Discipline> disciplines = new List<Discipline>();

        public Teacher(string name) : base(name)
        {            
            this.disciplines = new List<Discipline>();
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public override string ToString()
        {
            return $"Teacher Name: {base.Name}, Disciplines: {string.Join(", ", this.disciplines)}";
        }
    }
}