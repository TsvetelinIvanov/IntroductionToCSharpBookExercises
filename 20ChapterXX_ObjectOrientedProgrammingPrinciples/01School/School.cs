using System;
using System.Collections.Generic;

namespace _01School
{
    public class School
    {
        private string name;
        private List<SchoolClass> schoolClasses;

        public School(string name)
        {
            this.name = name;
            this.schoolClasses = new List<SchoolClass>();
        }

        public void AddClass(SchoolClass schoolClass)
        {
            this.schoolClasses.Add(schoolClass);
        }

        public override string ToString()
        {
            return $"School Name: {this.name}{Environment.NewLine}School classes:{Environment.NewLine}{string.Join(Environment.NewLine, this.schoolClasses)}";
        }
    }
}