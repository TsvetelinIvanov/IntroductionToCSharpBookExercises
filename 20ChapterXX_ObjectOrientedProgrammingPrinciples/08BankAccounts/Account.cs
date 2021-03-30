using System;

namespace _08BankAccounts
{
    public abstract class Account : IAccount
    {
        private bool isCompany;        
        private decimal interestRate;
        private decimal balance;

        protected Account(bool isCompany, decimal balance, decimal interestRate)
        {
            this.isCompany = isCompany;            
            this.interestRate = interestRate;
            this.balance = balance;
        }

        public bool IsCompany => this.isCompany;

        public decimal InterestRate => this.interestRate;

        public decimal Balance 
        {
            get { return this.balance; }
            set { this.balance = value; }
        }        
        
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("The amount must be positive number!");
            }

            this.balance += amount;
        }

        public abstract decimal CalculateInterest(int monthsCount);
    }
}