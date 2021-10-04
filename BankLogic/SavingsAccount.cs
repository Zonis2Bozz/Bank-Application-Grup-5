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

        public SavingsAccount(AccountType accountType, long customerId, int accountNumber, decimal accountBalance)
        {
            AccountType = accountType;
            CustomerId = customerId;
            AccountBalance = accountBalance;
            AccountNumber = accountNumber;
        }
        public SavingsAccount(AccountType accountType, long customerId)
        {
            AccountNumber = 1;
            AccountType = accountType;
            CustomerId = customerId;
            AccountBalance = 0;
        }

        public SavingsAccount(SavingsAccount savingsAccount)
        {
            AccountNumber = savingsAccount.AccountNumber;
            Interest = savingsAccount.Interest;
            AccountType = savingsAccount.AccountType;
            CustomerId = savingsAccount.CustomerId;
            AccountBalance = savingsAccount.AccountBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                AccountBalance += amount;
                Console.WriteLine($"Deposited {amount} new balance:{AccountBalance}");
            }
            else
            {
                Console.WriteLine("Cant deposit negative numbers");
            }
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
            List<SavingsAccount> data = DataAccess.CSV.Read<SavingsAccount>(Bank.FilePathSavingsAccount);
            return data;
        }
    }
}
