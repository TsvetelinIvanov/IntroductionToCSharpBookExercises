namespace _08BankAccounts
{
    public class Loan : Account
    {
        public Loan(bool isCompany, decimal balance, decimal interestRate) : base(isCompany, balance, interestRate)
        {

        }

        public override decimal CalculateInterest(int monthsCount)
        {
            int noInterestMonthsCount = 3;
            if (this.IsCompany)
            {
                noInterestMonthsCount = 2;
            }            

            decimal interest = 0;
            if (monthsCount <= noInterestMonthsCount)
            {
                return interest;
            }

            monthsCount -= noInterestMonthsCount;
            interest = monthsCount * this.InterestRate;

            return interest;
        }
    }
}