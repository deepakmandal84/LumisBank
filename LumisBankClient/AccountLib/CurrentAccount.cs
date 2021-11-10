using LumisBankClient.DTO;
using LumisBankClient.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumisBankClient.AccountLib
{
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(string accountName, decimal initialBal) : base(accountName, initialBal)
        {

        }
      
    }
}
