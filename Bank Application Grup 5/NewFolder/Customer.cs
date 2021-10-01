using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_Grup_5
{
    class Customer:SavingsAccount
    {
        private int customerName { get; set; }
        private int customerSocialNumber { get; set; } // valde string lättare att formetera
        private List<string> customerAccount { get; set; }

        public void ChangeCustomerName(string name, int socialNumber)
        {
            //ändrar kundens gammla namn och sparar kundens nya namn
        }
        public /*List<string>*/ void RemoveCustomer(int socialNumber)
        {

        }


        // implementera en metod som ska låta andvändaren se
        // information om kunden som T:ex kontonummer, saldo, kontotyp, räntesats
        // kanske ärva av SavingAccount och BankLogic för båda ska ha samma typ av metod
    }
}
