﻿using System.Linq;
using System.Text.RegularExpressions;

namespace BankLogic
{
    /// <summary>
    /// Class that validate differnt objects
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Validates string as name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ValidateName(this string name)
        {
            return Regex.Match(name, "^[a-öA-Ö]*$").Success;
        }

        /// <summary>
        /// Checks if given string can be parsed as long and lenght of 8
        /// </summary>
        /// <param name="socialNumber"></param>
        /// <returns></returns>
        public static bool ValidateSocialNumber(this string socialNumber)
        {
            if (long.TryParse(socialNumber, out long _))
            {
                return Regex.IsMatch(socialNumber, "\\A[0-9]{8}\\z");
            }
            return false;
        }
        /// <summary>
        /// Checks if customer exists by the socialnumber returns true if not foun
        /// </summary>
        /// <param name="socialNumber"></param>
        /// <returns></returns>
        public static bool ValidateCustomerNotExisting(this long socialNumber)
        {
            var list = Bank.GetCustomers().FirstOrDefault(customer => customer.GetCustomerSocialNumber() == socialNumber);
            return list == null;
        }
    }
}
