namespace _05EstateCompany
{
    public class Employee
    {
        private string name;

        public Employee(string name, string position, int monthsIntership)
        {
            this.name = name;
            this.Position = position;
            this.MonthsIntership = monthsIntership;
        }

        public string Position { get; set; }

        public int MonthsIntership { get; set; }

        public override string ToString()
        {
            return $"Employee Name: {this.name}, Position: {this.Position}, Intership: {this.MonthsIntership} months";
        }
    }
}