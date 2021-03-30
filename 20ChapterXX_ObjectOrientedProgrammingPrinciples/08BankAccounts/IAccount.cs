namespace _08BankAccounts
{
    public interface IAccount
    {
        bool IsCompany { get; }

        decimal Balance { get; set; }

        decimal InterestRate { get; }

        void Deposit(decimal amount);

        decimal CalculateInterest(int monthsCount);
    }
}