using System;
using System.Collections.Generic;

namespace BankLogic
{
    public class Customer
    {
        // Names
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; private set; }



        public readonly long CustomerSocialNumber;
        public List<SavingsAccount> CustomerAccounts { get; private set; }
        public int NumberOfAccounts { get; private set; } = 0;




        public Customer(string firstName, string lastName, long socialNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = firstName + " " + lastName;
            CustomerSocialNumber = socialNumber;
            CustomerAccounts = new List<SavingsAccount>();
        }

        public void ChangeCustomerFirstName(string name, long socialNumber)
        {
            //ändrar kundens gammla namn och sparar kundens nya namn
        }
        public void CreateAccount()
        {
            NumberOfAccounts++;
            CustomerAccounts.Add(new SavingsAccount(AccountType.Savings, CustomerSocialNumber));
        }

        


        public /*List<string>*/ void RemoveCustomer(long socialNumber)
        {

        }
        
        //public List<SavingsAccount> ReturnAccountsFromCustomer()
        //{
        //    return CustomerAccounts;
        //}

        // implementera en metod som ska låta andvändaren se
        // information om kunden som T:ex kontonummer, saldo, kontotyp, räntesats
        // kanske ärva av SavingAccount och BankLogic för båda ska ha samma typ av metod

    }
}
