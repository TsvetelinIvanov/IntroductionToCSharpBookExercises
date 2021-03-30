namespace _03Students
{
    public class Worker : Human
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

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:f2}; Work Hours: {this.WorkHoursCount}; Money per Hour: {this.MoneyPerHour():f2}.";
        }
    }
}