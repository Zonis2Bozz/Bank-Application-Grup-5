using System.Collections.Generic;
using System.Linq;

namespace BankLogic
{
    public static class Bank
    {
        public const string FilePathCustomer = "Data\\customer.csv";
        public const string FilePathSavingsAccount = "Data\\savingsAccounts.csv";

        private static List<Customer> AllCustomers { get; set; }
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


        public static void AddCustomer(Customer customer)
        {
            AllCustomers.Add(new Customer(customer));
        }


        /// <summary>
        /// Returns a list of all accounts
        /// </summary>
        /// <returns></returns>
        public static List<SavingsAccount> GetAllSavingsAccounts()
        {
            return AllCustomers.SelectMany(x => x.GetAccounts()).Distinct().ToList();
        }

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

        public static void SaveToDB()
        {
            DataAccess.CSV.Write<Customer>(AllCustomers, FilePathCustomer);
            DataAccess.CSV.Write<SavingsAccount>(GetAllSavingsAccounts(), FilePathSavingsAccount);
        }
    }
}
