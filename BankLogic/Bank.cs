using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BankLogic
{
    public class Bank
    {
        private static List<Customer> AllCustomers { get; set; }
        private static List<SavingsAccount> AllAccounts { get; set; }
        public Bank()
        {
            AllCustomers = new List<Customer>();
            AllAccounts = new List<SavingsAccount>();
        }
        public static List<Customer> GetCustomers()
        {
            return AllCustomers;
        }

        public static Customer GetCustomerBySocialNumber(long socialNumber)
        {
            if (AllCustomers != null)
            {
                foreach (var customer in AllCustomers)
                {
                    if (customer.CustomerSocialNumber == socialNumber)
                    {
                        return customer;
                    }
                }
            }

            return null;
        }

        public static bool AddCustomer(string firstName, string lastName, long socialNumber)
        {
            bool success = false;
            if (ValidateCustomerSocialNumber(socialNumber))
            {
                if (ValidateCustomerNames(firstName, lastName))
                {
                AllCustomers.Add(new Customer(firstName, lastName, socialNumber));
                    success = true;
                }
            }
            return success;
        }
        public static bool ValidateCustomerSocialNumber(long socialNumber)
        {
            bool validated = true;
            if (Regex.IsMatch(socialNumber.ToString(), "\\A[0-9]{12}\\z"))
            {
                foreach (var customer in AllCustomers)
                {
                    if(socialNumber == customer.CustomerSocialNumber)
                    {

                        validated = false;
                        break;
                    }
                }
            }
            else
            {
                validated = false;
            }
            return validated;
        }

        public static bool ValidateCustomerNames(string firstName, string lastName)
        {
            bool validated = false;
            if (Regex.Match(firstName, "^[A-Z][a-zA-Z]*$").Success)
            {
                if (Regex.Match(lastName, "^[A-Z][a-zA-Z]*$").Success)
                {
                    validated = true;
                }
            }
            return validated;
        }

        public static List<SavingsAccount> GetSavingsAccounts()
        {
            List<SavingsAccount> savingsAccounts = new();


            for (int i = 0; i < AllCustomers.Count; i++)
            {
                for (int j = 0; j < AllCustomers[i].CustomerAccounts.Count; j++)
                {
                    savingsAccounts.Add(AllCustomers[i].CustomerAccounts[j]);
                }
            }
            AllAccounts = savingsAccounts;
            return savingsAccounts;
        }

        public static void ReadFromDB()
        {
            AllCustomers = Customer.ReadFromDB();
            foreach (var account in SavingsAccount.ReadFromDB())
            {
                foreach (var customer in AllCustomers)
                {
                    if (customer.CustomerSocialNumber == account.CustomerId)
                    {
                        customer.CreateAccount(account);
                    }
                }
            }
            
        }

        public static void SaveToDB()
        {
            Bank.GetSavingsAccounts();
            DataAccess.CSV.Write<Customer>(AllCustomers, "customer.csv");
            DataAccess.CSV.Write<SavingsAccount>(AllAccounts, "savingsAccounts.csv");
        }
    }
}
