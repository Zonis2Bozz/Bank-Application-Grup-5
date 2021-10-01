using BankLogic;
using System;
using System.Collections.Generic;

namespace BankUI
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();
            List<Customer> list = new();

            if (bank.AddCustomer("Fredrik", "Jonson", 199305079619))
            {
                list = Bank.GetCustomers();
                Console.WriteLine($"Added {list[0].FullName}");
            }






            list[0].CreateAccount();
            list[0].CreateAccount();
            list[0].CreateAccount();
            list[0].CreateAccount();

            while (true)
            {
                var currentCustomer = list[0];

                foreach (var account in currentCustomer.CustomerAccounts)
                {
                    Console.WriteLine(account.ToString());
                }
                Console.WriteLine("choose account");
                int currentAccount = 0;
                while (true)
                {
                    currentAccount = int.Parse(Console.ReadLine());
                    if (currentAccount > 0 && currentAccount <= currentCustomer.NumberOfAccounts)
                    {
                        break;
                    }
                    Console.WriteLine($"Invalid input 1-{currentCustomer.NumberOfAccounts}");
                }
                currentAccount--;
                while (true)
                {
                    Console.WriteLine(currentCustomer.CustomerAccounts[currentAccount].ToString());
                    Console.WriteLine("Enter amount to withdraw");
                    decimal amount = decimal.Parse(Console.ReadLine());


                    if (currentCustomer.CustomerAccounts[currentAccount].Withdraw(amount))
                    {
                        break;
                    }
                }
            }
        }
    }
}
