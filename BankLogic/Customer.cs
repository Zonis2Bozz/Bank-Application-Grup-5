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


        /// <summary>
        /// CSV helper needs this ctor to construct list<Customer> from csv file
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="customerSocialNumber"></param>
        /// <param name="customerSince"></param>
        /// <param name="numberOfAccounts"></param>
        public Customer(string firstName, string lastName, long customerSocialNumber, string customerSince, int numberOfAccounts)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerSocialNumber = customerSocialNumber;
            CustomerSince = customerSince;
            NumberOfAccounts = numberOfAccounts;
        }
     
        
        
        public Customer(string firstName, string lastName, long socialNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerSocialNumber = socialNumber;
            NumberOfAccounts = 0;
        }



        /// <summary>
        /// returns customer full name
        /// </summary>
        /// <returns></returns>
        public string GetCustomerName()
        {
            return FirstName + " " + LastName;
        }


        /// <summary>
        /// Returns customers socialnumber
        /// </summary>
        /// <returns></returns>
        public long GetCustomerSocialNumber()
        {
            return CustomerSocialNumber;
        }



        /// <summary>
        /// returns Customers list<SavingsAccounts>s
        /// </summary>
        /// <returns></returns>
        public List<SavingsAccount> GetAccounts()
        {
            return CustomerAccounts;
        }


        /// <summary>
        /// Method to change customer name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="socialNumber"></param>
         public void ChangeCustomerName(string name, long socialNumber)
        {
            //ändrar kundens gammla namn och sparar kundens nya namn
        } //NULL



        /// <summary>
        /// Returns the account from customer account with supplied account number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
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



        /// <summary>
        /// Method to create a completly new account and add it to customer list
        /// </summary>
        /// <param name="accountType"></param>
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



        /// <summary>
        /// Metod to create and add existing accounst from csv file to Customers list of account
        /// </summary>
        /// <param name="savingsAccounts"></param>
        public void CreateAccount(SavingsAccount savingsAccounts)
        {
            CustomerAccounts.Add(new SavingsAccount(savingsAccounts));
        }



        /// <summary>
        /// Prints name, socialnumber, and customer since
        /// </summary>
        /// <returns></returns>
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
