namespace _08BankAccounts
{
    public interface IDeposit : IAccount
    {
        bool Withdraw(decimal amount);
    }
}