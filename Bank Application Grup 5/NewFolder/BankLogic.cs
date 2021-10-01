using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Application_Grup_5
{
    class BankLogic:Customer
    {
        private List<string> allCustomers { get; set; }
        public List<string> GetCustomers()
        {
            return allCustomers;
        }
        public List<string> GetCustomer(long socialNumber)
        {
            return allCustomers;
        }

        public bool AddCustomer(string name, int socialNumber)
        {
            return true;
        }


    }
}
