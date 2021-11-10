using LumisBankClient.DTO;
using LumisBankClient.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumisBankClient.AccountLib
{
    public class StudentAccount : BankAccount
    {
        public StudentAccount(string accountName, decimal initialBal) : base(accountName, initialBal)
        {

        }
       
       
        public override bool WithDrawFunds(decimal amount)
        {
            bool sucess = false;
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            var lastTransactions = base.SearchTransaction(TransactionType.Withdraw, startDate, endDate);
            if (lastTransactions.Count <5)
            {
                sucess= base.WithDrawFunds(amount);
            }
            else
            {
                throw new Exception("Only a maximum of 5 withdrawals are allowed for the current month");
            }

            return sucess;
        }
    }
}
