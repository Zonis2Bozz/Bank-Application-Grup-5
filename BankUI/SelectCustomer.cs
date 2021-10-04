using BankLogic;
using System;
using System.Threading;

namespace BankUI
{
    class Select
    {
        private static Customer CurrentCustomer { get; set; }
        public static void Customer()
        {
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Select by social number [e] to go back to menu");
                Console.WriteLine("----------------------------------------------");
                Console.Write("Enter socialnumber:");
                long.TryParse(Console.ReadLine(), out long socialNumber);
                CurrentCustomer = Bank.GetCustomerBySocialNumber(socialNumber);
                if (CurrentCustomer != null)
                {
                    quit = true;
                    Console.Clear();
                    CustomerMenu();
                }
                else
                {
                    Console.WriteLine($"No customer with social number{socialNumber} found");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

            }
        }

        private static void CustomerMenu()
        {
            bool quit = false;
            while (!quit)
            {
                PrintCustomerHeader();
                Console.WriteLine("1. Show accounts\n2. Change name\n3. Terminate account\n4. Mainmenu");
                _ = Int32.TryParse(Console.ReadLine(), out int menu);
                switch (menu)
                {
                    case 1:
                        foreach (var account in CurrentCustomer.GetAccounts())
                        {
                            Console.WriteLine(account.ToString());
                        }
                        AccountMenu();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        private static void AccountMenu()
        {

        }

        private static void PrintCustomerHeader()
        {
            string header = CurrentCustomer.GetCustomerName() + ":" + CurrentCustomer.GetCustomerSocialNumber();
            string lines = string.Empty;
            foreach (var letter in header)
            {
                lines += "-";
            }
            Console.WriteLine(header + "\n" + lines);
        }
    }
}
