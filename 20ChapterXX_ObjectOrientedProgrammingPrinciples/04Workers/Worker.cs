using System;

namespace _04Workers
{
    public class Worker : Human, IComparable<Worker>
    {
        private decimal salary;
        private int workHoursCount;

        public Worker(string personalName, string familyName, decimal salary, int workHoursCount) : base(personalName, familyName)
        {
            this.salary = salary;
            this.workHoursCount = workHoursCount;
        }

        public decimal Salary => this.salary;

        public int WorkHoursCount => this.workHoursCount;        

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = this.Salary / this.WorkHoursCount;

            return moneyPerHour;
        }

        public int CompareTo(Worker otherWorker)
        {
            return otherWorker.Salary.CompareTo(this.Salary);
        }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:f2}; Work Hours: {this.WorkHoursCount}; Money per Hour: {this.MoneyPerHour():f2}.";
        }
    }
}
