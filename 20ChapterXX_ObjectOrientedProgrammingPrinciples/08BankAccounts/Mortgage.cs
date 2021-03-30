namespace _08BankAccounts
{
    public class Mortgage : Account
    {
        public Mortgage(bool isCompany, decimal balance, decimal interestRate) : base(isCompany, balance, interestRate)
        {

        }

        public override decimal CalculateInterest(int monthsCount)
        {
            if (this.IsCompany)
            {
                return CalculateCompanyInterest(monthsCount);
            }
            else
            {
                return CalculateIndividualInterest(monthsCount);
            }
        }

        private decimal CalculateCompanyInterest(int monthsCount)
        {
            int halfInterestRateMountsCount = 12;
            decimal interest;
            if (monthsCount <= halfInterestRateMountsCount)
            {
                interest = (this.InterestRate / 2) * monthsCount;

                return interest;
            }
            else
            {
                monthsCount -= halfInterestRateMountsCount;
                interest = ((this.InterestRate / 2) * halfInterestRateMountsCount) + this.InterestRate * monthsCount;

                return interest;
            }
        }

        private decimal CalculateIndividualInterest(int monthsCount)
        {
            int noInterestMountsCount = 6;
            decimal interest = 0;
            if (monthsCount <= noInterestMountsCount)
            {
                return interest;
            }
            else
            {
                monthsCount -= noInterestMountsCount;
                interest = monthsCount * this.InterestRate;

                return interest;
            }
        }
    }
}