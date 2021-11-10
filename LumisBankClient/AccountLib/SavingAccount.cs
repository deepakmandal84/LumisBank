using LumisBankClient.DTO;
using LumisBankClient.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumisBankClient.AccountLib
{
    public class SavingAccount : BankAccount
    {

        private double _interestRate;

        public SavingAccount(string accountName, decimal initialBal) :base(accountName,initialBal)
        {
            _interestRate = base.CalculateInterestRate();
        }

        public override double CalculateInterestRate()
        {
            return _interestRate;
        }

        public override bool DepositFunds(decimal amount)
        {
            bool sucess = base.DepositFunds(amount);

            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            var lastTransactions = base.SearchTransaction(TransactionType.Deposit, startDate, endDate);
            if(lastTransactions.Sum(a=>a.Amount) > 10000)
            {
                _interestRate = 3.0;
            }
            return true;
        }


        public override bool WithDrawFunds(decimal amount)
        {
            bool sucess = base.WithDrawFunds(amount);
            if (sucess)
            {
                //After WithDrawing from accountbalanc
                DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endDate = startDate.AddMonths(1).AddDays(-1);
                var lastTransactions = base.SearchTransaction(TransactionType.Withdraw, startDate, endDate);
                if (lastTransactions.Count > 3)
                {
                    _interestRate = 0;
                }
            }
           

            return sucess;
        }

    }
}
