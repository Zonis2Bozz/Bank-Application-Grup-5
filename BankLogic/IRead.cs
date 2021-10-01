using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLogic
{
    interface IRead
    {
        public void ReadFromDB();

        public void SaveToDB();
    }
}
