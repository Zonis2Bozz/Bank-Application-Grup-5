using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{
    public enum AccountType
    {
        Savings,
        Spending
    }
    public class SavingsAccount
{
        public long AccountNumber { get; }
        public double Interest { get; private set; }
        public AccountType AccountType { get;}
        public long CustomerId { get;}
        public decimal AccountBalance { get; set; }

        private SavingsAccount(int accountNumber, AccountType accountType, long customerId, decimal accountBalance)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            CustomerId = customerId;
            AccountBalance = accountBalance;
        }
        public SavingsAccount(AccountType accountType, long customerId)
        {
            AccountType = accountType;
            CustomerId = customerId;
            AccountBalance = 1000;
        }

        public SavingsAccount(SavingsAccount savingsAccount)
        {
            Interest = savingsAccount.Interest;
            AccountType = savingsAccount.AccountType;
            CustomerId = savingsAccount.CustomerId;
            AccountBalance = savingsAccount.AccountBalance;
        }

        public void Deposit(decimal amount)
        {
            AccountBalance += amount;
            Console.WriteLine();
        }

        public bool Withdraw(decimal amount)
        {
            bool validated = false;
            if (amount > 0 && AccountBalance - amount >= 0)
            {
                Console.WriteLine($"Withdrew {amount:C} from Account");
                AccountBalance -= amount;
                validated = true;
            }
            else if (amount <= 0)
            {
                Console.WriteLine("You cant withdraw negative amounts");
            }
            else
            {
                Console.WriteLine($": Balance to low");
            }
            return validated;
        }
        public override string ToString()
        {
            return $"{AccountType}:Balance:{AccountBalance}";
        }
        public static List<SavingsAccount> ReadFromDB()
        {
            List<SavingsAccount> data = DataAccess.CSV.Read<SavingsAccount>("savingsAccounts.csv");
            return data;
        }
        public static void SaveToDB()
        {
            DataAccess.CSV.Write<SavingsAccount>(Bank.GetSavingsAccounts(), "savingsAccounts.csv");
        }
    }
}
