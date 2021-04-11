using System;
using System.Collections.Generic;

namespace _05EstateCompany
{
    public class EstateCompany
    {
        private string name;
        private string bulstat;
        private HashSet<Employee> employees;
        private HashSet<Estate> estates;

        public EstateCompany(string name, string bulstat, IEnumerable<Employee> employees, IEnumerable<Estate> estates)
        {
            this.name = name;
            this.bulstat = bulstat;
            this.employees = new HashSet<Employee>(employees);
            this.estates = new HashSet<Estate>(estates);
        }

        public bool AddEmployee(Employee employee)
        {
            return this.employees.Add(employee);
        }

        public bool RemoveEmployee(Employee employee)
        {
            return this.employees.Remove(employee);
        }

        public bool AddEstate(Estate estate)
        {
            return this.estates.Add(estate);
        }

        public bool RemoveEstate(Estate estate)
        {
            return this.estates.Remove(estate);
        }

        public override string ToString()
        {
            return $"Company Name: {this.name}{Environment.NewLine}Bulstat: {this.bulstat}{Environment.NewLine}Employees ({this.employees.Count}): {string.Join("; ", this.employees)}.{Environment.NewLine}Estates: {this.estates.Count}{Environment.NewLine}{string.Join(Environment.NewLine, this.estates)}{Environment.NewLine}{new string('-', 20)}";
        }
    }
}