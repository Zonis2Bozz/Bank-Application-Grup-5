using System;
using System.Collections.Generic;

namespace BankLogic
{
    public class Customer
    {
        // Names
        public string FirstName { get; private set; }
        public string LastName { get; private set; }


        public long CustomerSocialNumber { get; }
        public string CustomerSince { get;} = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        private List<SavingsAccount> CustomerAccounts { get; set; } = new List<SavingsAccount>();
        public int NumberOfAccounts { get; private set; }
        public Customer(Customer customer)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            CustomerSocialNumber = customer.CustomerSocialNumber;
            CustomerSince = customer.CustomerSince;
            NumberOfAccounts = customer.NumberOfAccounts;
        }

        public Customer(string firstName, string lastName, long customerSocialNumber, string customerSince, int numberOfAccounts)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerSocialNumber = customerSocialNumber;
            CustomerSince = customerSince;
            NumberOfAccounts = numberOfAccounts;
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
        public Customer(string firstName, string lastName, long socialNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerSocialNumber = socialNumber;
            NumberOfAccounts = 0;
        }

        public void ChangeCustomerName(string name, long socialNumber)
        {
            //ändrar kundens gammla namn och sparar kundens nya namn
        } //NULL
        public void CreateAccount()
        {
            if (NumberOfAccounts < 5)
            {
                NumberOfAccounts++;
                CustomerAccounts.Add(new SavingsAccount(AccountType.Savings, CustomerSocialNumber));
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

        public void RemoveCustomer(long socialNumber)
        {


        }
        
        public override string ToString()
        {
            return $"Name:{FirstName} {LastName}\nID:{CustomerSocialNumber}:Created:{CustomerSince}";
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
