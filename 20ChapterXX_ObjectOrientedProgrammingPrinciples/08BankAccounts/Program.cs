using System;
using System.Text;

namespace _08BankAccounts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(ReadAccountsAndPrintInterestRates());
        }

        static string ReadAccountsAndPrintInterestRates()
        {
            int accountsCount = int.Parse(Console.ReadLine());
            StringBuilder resultBuilder = new StringBuilder();
            for (int currAcc = 0; currAcc < accountsCount; currAcc++)
            {
                string account = Console.ReadLine();
                string interestRate = GetIterestRate(account);
                resultBuilder.AppendLine(interestRate);
            }

            return resultBuilder.ToString();
        }

        static string GetIterestRate(string account)
        {
            string[] accountDetails = account.Split();
            string accountType = accountDetails[0] + " " + accountDetails[1];
            decimal balance = decimal.Parse(accountDetails[2]);
            decimal interestRate = decimal.Parse(accountDetails[3]);
            int monthsCount = int.Parse(accountDetails[4]);

            string output;
            switch (accountType)
            {
                case "deposit individual":
                case "deposit company":
                    {
                        output = GetDepositInterestRate(balance, interestRate, monthsCount);
                        break;
                    }
                case "loan individual":
                    {
                        output = GetIndividualLoanInterestRate(balance, interestRate, monthsCount);
                        break;
                    }
                case "loan company":
                    {
                        output = GetCompanyLoanInterestRate(balance, interestRate, monthsCount);
                        break;
                    }
                case "mortgage individual":
                    {
                        output = GetIndividualMortgageInterestRate(balance, interestRate, monthsCount);
                        break;
                    }
                case "mortgage company":
                    {
                        output = GetCompanyMortgageInterestRate(balance, interestRate, monthsCount);
                        break;
                    }
                default:
                    throw new ArgumentException("Unrecognized account: " + accountType);
            }
            return output;
        }

        static string GetDepositInterestRate(decimal balance, decimal interestRate, int monthsCount)
        {
            Deposit deposit = new Deposit(true, balance, interestRate);
            decimal rate = deposit.CalculateInterest(monthsCount);

            return $"{rate:F2}";
        }

        static string GetIndividualLoanInterestRate(decimal balance, decimal interestRate, int monthsCount)
        {
            Loan loan = new Loan(false, balance, interestRate);
            decimal rate = loan.CalculateInterest(monthsCount);

            return $"{rate:F2}";
        }

        static string GetCompanyLoanInterestRate(decimal balance, decimal interestRate, int monthsCount)
        {
            Loan loan = new Loan(true, balance, interestRate);
            decimal rate = loan.CalculateInterest(monthsCount);

            return $"{rate:F2}";
        }

        static string GetIndividualMortgageInterestRate(decimal balance, decimal interestRate, int monthsCount)
        {
            Mortgage mortgage = new Mortgage(false, balance, interestRate);
            decimal rate = mortgage.CalculateInterest(monthsCount);

            return $"{rate:F2}";
        }

        static string GetCompanyMortgageInterestRate(decimal balance, decimal interestRate, int monthsCount)
        {
            Mortgage mortgage = new Mortgage(true, balance, interestRate);
            decimal rate = mortgage.CalculateInterest(monthsCount);

            return $"{rate:F2}";
        }
    }
}