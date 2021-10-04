using BankLogic;
using System;
using System.Threading;

namespace BankUI
{
    public static class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            do
            {
                Bank.ReadFromDB();
                Console.WriteLine("1. Add new customer\n2. Select Customer\n3. Show all customers\n4. Exit");
                _ = Int32.TryParse(Console.ReadLine(), out int menu);
                switch (menu)
                {
                    case 1: // Adds a new user, logic inside Class Add
                        if (Add.Customer()) Console.WriteLine("Customer added");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    case 2:
                        Select.Customer();
                        break;
                    case 3:
                        foreach (var customer in Bank.GetCustomers())
                        {
                            Console.WriteLine(customer.ToString());
                        }
                        Console.ReadLine();
                        break;
                    case 4:
                        quit = true;
                        break;
                    case 5:
                        foreach (var customer in Bank.GetCustomers())
                        {
                            Console.WriteLine(customer.ToString());
                            foreach (var account in customer.GetAccounts())
                            {
                                Console.WriteLine(account.ToString());
                            }
                        }
                        break;
                    default:
                        break;
                }
                Bank.SaveToDB();



            } while (!quit);
        }


        public static string FirstToUpper(this string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                string temp = name.ToLower();
                string save = string.Empty;
                save += char.ToUpper(temp[0]);
                save += temp[(0 + 1)..];
                name = save;
                return save;
            }
            return name;
        }
    }
}
