namespace _08BankAccounts
{
    public class Deposit : Account, IDeposit
    {
        public Deposit(bool isCompany, decimal balance, decimal interestRate) : base(isCompany, balance, interestRate)
        {

        }

        public bool Withdraw(decimal amount)
        {
            if (amount > this.Balance)
            {
                return false;
            }

            this.Balance -= amount;

            return true;
        }

        public override decimal CalculateInterest(int monthsCount)
        {
            decimal interest = 0;
            if (this.Balance >= 0 && this.Balance < 1000)
            {
                return interest;
            }

            interest = monthsCount * this.InterestRate;

            return interest;
        }
    }
}
