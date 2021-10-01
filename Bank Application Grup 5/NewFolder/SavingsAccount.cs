using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_Grup_5
{
    class SavingsAccount
    {
        private string account { get; set; }
        public double accountBalance { get; set; }
        public int accountId { get; set; }

        public void Transaction(double balance)
        {
            //först ta reda på vad dom har skrivit
            //med en metod
            // ex -100/+100 tar bort/lägger till hundra kr

            //kontrollera om när dom tar ut x 
            //är större än totala saldio y
            //x>Y funkar inte funktionen

            //Spara nya värdet i data base
        }
        public double InterestRate(double balance)
        {
            // räknar ut ens ränta enligt formula
            double intrestRate = (balance*0.01)/100;
            return intrestRate;
            // ska också presentera 
            //kontonummer, saldo, kontotyp, räntesats
            //tillsamans med ränta
            //Gör en metod för det
        }
        public /*int*/ void AddSavingsAccount(int socialNumber)
        {
            
        }
        public string CloseAccount(long socialNumber, int accountId)
        {
            return "";
        }
        public string GetAccount(int socialumber, int accountId)
        {
            return account;
        }


    }
}
