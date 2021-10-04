using BankLogic;
using System;
using System.Threading;

namespace BankUI
{
    class Add
    {
        public static bool Customer()
        {
            bool validated = false;
            bool quit = false;

            var newCustomer = Create();
            if (newCustomer != null)
            {
                while (!quit)
                {
                    Console.WriteLine($"Do you want to add {newCustomer.GetCustomerName()} (Y/N)");
                    switch (Console.ReadLine().ToLower())
                    {
                        case "y":
                            Bank.AddCustomer(newCustomer);
                            quit = true;
                            validated = true;
                            break;
                        case "n":
                            quit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid inp (Y/N)");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                    }
                }
            }
            return validated;
        }

        private static Customer Create()
        {
            string firstName;
            string lastName;
            long socialNumber;

            Console.Clear();

            firstName = Name("First");
            Console.Clear();

            if (firstName == null) return null;
            lastName = Name("Last");

            Console.Clear();
            if (lastName == null) return null;
            socialNumber = SocialNumber();

            Console.Clear();
            if (socialNumber < 0) return null;

            var newCustomer = new Customer(firstName, lastName, socialNumber);

            return newCustomer;
        }
        private static string Name(string firstOrLast)
        {
            string name;
            while (true)
            {
                PrintHeader();
                Console.Write($"{firstOrLast}name: ");
                name = Console.ReadLine();
                if (name.ToLower() == "e")
                {
                    return null;
                }
                else if (name.ValidateName())
                {
                    name = name.FirstToUpper();
                    return name;
                }
                else
                {
                    Console.WriteLine("Invalid Input A-ö allowed");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
        private static long SocialNumber()
        {
            while (true)
            {
                PrintHeader();
                Console.Write("Socialnumber: ");
                string social = Console.ReadLine();
                if (social.ToLower() == "e")
                {
                    return -1;
                }
                else if(social.ValidateSocialNumber())
                {
                    _ = long.TryParse(social, out long socialNumber);
                    if (socialNumber.ValidateCustomerNotExisting())
                    {
                        return socialNumber;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Customer with socialnumber: {socialNumber} does already existing");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input (8 digits)");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
        private static void PrintHeader()
        {
            Console.WriteLine("Adding a new customer [e] to end");
            Console.WriteLine("--------------------------------");
        }
    }
}
