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

        public List<SavingsAccount> CustomerAccounts { get; private set; }
        public int NumberOfAccounts { get; private set; } = 0;


        public Customer(string firstName, string lastName, long customerSocialNumber, string customerSince)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerSocialNumber = customerSocialNumber;
            CustomerSince = customerSince;
        }


        public Customer(string firstName, string lastName, long socialNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerSocialNumber = socialNumber;
            CustomerAccounts = new List<SavingsAccount>();        
        }

        public void ChangeCustomerName(string name, long socialNumber)
        {
            //ändrar kundens gammla namn och sparar kundens nya namn
        } //NULL
        public void CreateAccount()
        {
            NumberOfAccounts++;
            CustomerAccounts.Add(new SavingsAccount(AccountType.Savings, CustomerSocialNumber));
        }
        public void CreateAccount(List<SavingsAccount> savingsAccounts)
        {
            foreach (var account in savingsAccounts)
            {
                
            }
        }

        public void RemoveCustomer(long socialNumber)
        {


        }
        
        public override string ToString()
        {
            return $"Name:{FirstName} {LastName}\nID:{CustomerSocialNumber}:Created:{CustomerSince}";
        }


        //SAVE/READ
        public static List<Customer> ReadFromDB()
        {
            List<Customer> data = DataAccess.CSV.Read<Customer>("customer.csv");
            return data;
        }
        public static void SaveToDB()
        {
            DataAccess.CSV.Write<Customer>(Bank.GetCustomers(), "customer.csv");
        }
    }
}
