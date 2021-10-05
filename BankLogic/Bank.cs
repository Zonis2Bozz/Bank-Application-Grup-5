using System.Collections.Generic;
using System.Linq;

namespace BankLogic
{
    public static class Bank
    {
        public const string FilePathCustomer = "Data\\customer.csv";
        public const string FilePathSavingsAccount = "Data\\savingsAccounts.csv";
        private static List<Customer> AllCustomers { get; set; }


        /// <summary>
        /// Returns a list<Customer> of all customers
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetCustomers()
        {
            return AllCustomers;
        }
        /// <summary>
        /// Returns a Customer with social number. Null if not found
        /// </summary>
        /// <param name="socialNumber"></param>
        /// <returns></returns>
        public static Customer GetCustomerBySocialNumber(long socialNumber)
        {
            if (AllCustomers != null)
            {
                return AllCustomers.FirstOrDefault(customer => customer.GetCustomerSocialNumber() == socialNumber);
            }

            return null;
        }

        /// <summary>
        /// Adds a customer to AllCustomer list
        /// </summary>
        /// <param name="customer"></param>
        public static void AddToCustomerList(Customer customer)
        {
            AllCustomers.Add(customer);
        }


        /// <summary>
        /// Returns a list of all accounts
        /// </summary>
        /// <returns></returns>
        public static List<SavingsAccount> GetAllSavingsAccounts()
        {
            return AllCustomers.SelectMany(x => x.GetAccounts()).Distinct().ToList();
        }

        /// <summary>
        /// Reads customer from Csv file and adds customers to AllCustomers
        /// Reads accounts from CSV file and adds all accounts to the right customer
        /// </summary>
        public static void ReadFromDB()
        {
            AllCustomers = Customer.ReadFromDB();

            // Loops all accounts and adds it to the right customer
            foreach (var account in SavingsAccount.ReadFromDB())
            {
                foreach (var customer in AllCustomers)
                {                 
                    if (customer.GetCustomerSocialNumber() == account.CustomerId)
                    {
                        customer.CreateAccount(account);
                    }
                }
            }
        }
        /// <summary>
        /// Saves all customers to CSV file
        /// Saves all accounts to CSV file
        /// </summary>
        public static void SaveToDB()
        {
            DataAccess.CSV.Write<Customer>(AllCustomers, FilePathCustomer);
            DataAccess.CSV.Write<SavingsAccount>(GetAllSavingsAccounts(), FilePathSavingsAccount);
        }
    }
}
