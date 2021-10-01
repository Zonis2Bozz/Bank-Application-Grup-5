using System;
using System.Collections.Generic;

namespace BankLogic
{
    public class Customer
    {
        // Names
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }


        public readonly long CustomerSocialNumber;
        private readonly string CustomerSince = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        public List<SavingsAccount> CustomerAccounts { get; private set; }
        public int NumberOfAccounts { get; private set; } = 0;




        public Customer(string firstName, string lastName, long socialNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = firstName + " " + lastName;
            CustomerSocialNumber = socialNumber;
            CustomerAccounts = new List<SavingsAccount>();        
        }
        private Customer(string firstName, string lastName, long socialNumber, string customerSince)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = firstName + " " + lastName;
            CustomerSocialNumber = socialNumber;
            CustomerSince = customerSince;
            CustomerAccounts = new List<SavingsAccount>();
        }

        public void ChangeCustomerName(string name, long socialNumber)
        {
            //ändrar kundens gammla namn och sparar kundens nya namn
        }
        public void CreateAccount()
        {
            NumberOfAccounts++;
            CustomerAccounts.Add(new SavingsAccount(AccountType.Savings, CustomerSocialNumber));
        }


        public void RemoveCustomer(long socialNumber)
        {


        }
        
        public List<SavingsAccount> ReturnAccountsFromCustomer()
        {
            return CustomerAccounts;
        }



        public override string ToString()
        {
            return $"Name:{FullName}-{CustomerSocialNumber}:Created:{CustomerSince}";
        }

        public void ReadFromDB()
        {
            var runner = new DataAccess.ReadFromCSV<Customer>();
            runner.Read("Path");

        }

        //public void SaveToDB(List<Customer> customerList)
        //{
        //    var runner = new DataAccess.ReadFromCSV<Customer>();
        //    runner.Write(customerList,"customer.csv");
        //}
    }
}
