using System;
using System.Collections.Generic;
using System.Linq;

namespace BankLogic
{
    public class Customer
    {
        // properties need to be public for CSV helper automap to work...
        public string FirstName { get; private set; }
        public string LastName { get; private set; }


        public long CustomerSocialNumber { get; }
        public string CustomerSince { get; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        private List<SavingsAccount> CustomerAccounts { get; set; } = new List<SavingsAccount>();
        public int NumberOfAccounts { get; private set; }


        public Customer(string firstName, string lastName, long customerSocialNumber, string customerSince, int numberOfAccounts)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerSocialNumber = customerSocialNumber;
            CustomerSince = customerSince;
            NumberOfAccounts = numberOfAccounts;
        }
        // public Customer(Customer customer)
        //  {
        //      FirstName = customer.FirstName;
        //      LastName = customer.LastName;
        //      CustomerSocialNumber = customer.CustomerSocialNumber;
        //      CustomerSince = customer.CustomerSince;
        //      NumberOfAccounts = customer.NumberOfAccounts;
        //  }
        public Customer(string firstName, string lastName, long socialNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerSocialNumber = socialNumber;
            NumberOfAccounts = 0;
        }

        public string GetCustomerName()
        {
            return FirstName + " " + LastName;
        }
        public long GetCustomerSocialNumber()
        {
            return CustomerSocialNumber;
        }
        public List<SavingsAccount> GetAccounts()
        {
            return CustomerAccounts;
        }

         public void ChangeCustomerName(string name, long socialNumber)
        {
            //ändrar kundens gammla namn och sparar kundens nya namn
        } //NULL

        public SavingsAccount GetAccountByAccountNumber(long accountNumber)
        {
            var temp = CustomerAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
            return temp;
        }


        /// <summary>
        /// Removes account from Customer and returns balance * interest
        /// if accountbalance 0 returns 0
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public decimal RemoveAccount(long accountNumber)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            CustomerAccounts.Remove(account);

            if (account.GetBalance() > 0)
            {
                return account.GetBalance() * account.Interest;
            }
            else
            {
                return 0;
            }
        }
        public void CreateAccount(AccountType accountType)
        {
            if (NumberOfAccounts < 5)
            {
                NumberOfAccounts++;
                CustomerAccounts.Add(new SavingsAccount(accountType, CustomerSocialNumber));
                Console.WriteLine("Account Created");
            }
            else
            {
                Console.WriteLine("You have to many accounts");
            }
        }
        public void CreateAccount(SavingsAccount savingsAccounts)
        {
            CustomerAccounts.Add(new SavingsAccount(savingsAccounts));
        }

        public override string ToString()
        {
            return $"Name:{FirstName} {LastName}ID:{CustomerSocialNumber}:Created:{CustomerSince}";
        }


        /// <summary>
        /// Reads customer from csv file and returns a list of customers
        /// Needs to be in customer class to automap customer and return a list of customers
        /// </summary>
        /// <returns></returns>
        public static List<Customer> ReadFromDB()
        {
            return DataAccess.CSV.Read<Customer>(Bank.FilePathCustomer);
        }
    }
}
