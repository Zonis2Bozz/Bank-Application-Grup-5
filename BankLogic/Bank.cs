using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BankLogic
{
    public class Bank //: IRead
    {
        private static List<Customer> AllCustomers { get; set; }
        public Bank()
        {
            AllCustomers = new List<Customer>();
        }
        public static List<Customer> GetCustomers()
        {
            return AllCustomers;
        }

        public static Customer GetCustomer(long socialNumber)
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

        public bool AddCustomer(string firstName, string lastName, long socialNumber)
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

        //public void ReadFromDB()
        //{
        //    var runner = new DataAccess.ReadFromCSV<Customer>();
        //    runner.Write(AllCustomers, "customer.csv");
        //}

        //public void SaveToDB()
        //{
        //    var runner = new DataAccess.ReadFromCSV<Customer>();
        //    runner.Write(AllCustomers, "customer.csv");
        //}
    }
}
