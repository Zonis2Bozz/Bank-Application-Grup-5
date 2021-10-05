using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BankLogic
{
    public static class Bank
    {
        public const string FilePathCustomer = "Data\\customer.csv";
        public const string FilePathSavingsAccount = "Data\\savingsAccounts.csv";
        public const string FilePathCurrentAccount = "Data\\currentAccount.csv";
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
        /// Remove customer
        /// </summary>
        /// <param name="socialNumber"></param>
        public static void RemoveCustomer(long socialNumber)
        {
            AllCustomers.Remove(GetCustomerBySocialNumber(socialNumber));
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




        // Getting account number to use when creating new account
        public static long GetCurrentAccountNumber()
        {
            long num = 0;

            using (StreamReader sr = File.OpenText(Bank.FilePathCurrentAccount))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    num = long.Parse(s);
                }
            }
            if (num > 1000)
            {
                SetCurrentAccountNumber( num);
                return num;
            }

            else
            {
                SetCurrentAccountNumber(1001);
                return 1001;              
            }
        }

        public static void SetCurrentAccountNumber(long num)
        {
            string text = string.Empty;
            text += num + 1;
            File.WriteAllText(Bank.FilePathCurrentAccount, text);

        }

    }
}
