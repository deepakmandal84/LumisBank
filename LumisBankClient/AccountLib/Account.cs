using LumisBankClient.DomainEntities;
using LumisBankClient.DTO;
using LumisBankClient.Middleware;
using LumisBankClient.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumisBankClient.AccountLib
{
    public abstract class BankAccount
    {
        /*
         * An base class is created with  attributes and methods which are used for child classes
         */

        private int _accountNumber;
        
        private static int LastAccountNumber = 0;
        private double _interestRate = 1;
        private AccountEntity _accountEntity;
        private decimal _balance;
        private readonly object _lockBalance = new object();
        public List<TransactionDto> _transactions;

        public  BankAccount(string accountName,decimal initialBal)
        {
            _transactions = new List<TransactionDto>();
            _accountEntity = new AccountEntity();
            _accountEntity.AccountName = accountName;

            this.AccountNumber = LastAccountNumber + 1;
            LastAccountNumber = this.AccountNumber;            
            DepositFunds(initialBal);
        }

        
        public int AccountNumber  
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public decimal AccountBalance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        /*
        public AccountEntity AccountEntity
        {
            get { return _accountEntity; }
            set { _accountEntity = value; }
        }
        public AccountEntity GetAccountEntity()
        {
            _accountEntity = AccountCollection.AccountEntities.Where(a => a.Id == _accountNumber).Single();//this will ensure i get only one account
            AccountEntity = _accountEntity;
            return AccountEntity;
        }
        */
        public virtual double CalculateInterestRate()
        {
            return _interestRate;
        }
        public virtual bool DepositFunds(decimal amount)
        {
            //var transactionType =  //AccountCollection.TransactionTypesEntities.Where(a => a.Code == Utilities.TransactionType.Deposit.ToString("g")).SingleOrDefault();
            if (amount < 0)
            {
                throw new Exception("Amount should be greater than 0");
            }
            lock (_lockBalance)
            {
                AccountBalance = AccountBalance + amount;
                var depositTransaction = new TransactionDto()
                {   
                    TransactionType = Utilities.TransactionType.Deposit,
                    Amount = amount,
                    Date=DateTime.Now,
                    User="user1"                    
                };
                //save it in database
                //AccountEntity.Transactions.Add(depositTransaction);
                _transactions.Add(depositTransaction);
            }
            return true;
        }
        public virtual bool WithDrawFunds(decimal amount)
        {
            //var transactionType = AccountCollection.TransactionTypesEntities.Where(a => a.Code == Utilities.TransactionType.Withdraw.ToString("g")).SingleOrDefault();

            if (amount < 0)
            {
                throw new Exception("Amount should be greater than 0");
            }
            lock (_lockBalance)
            {
                if (AccountBalance >= amount)
                {
                    //put a transaction in database
                    AccountBalance = AccountBalance - amount;
                    var withdrawtransaction = new TransactionDto()
                    {
                        TransactionType = Utilities.TransactionType.Withdraw,
                        Amount = amount,
                        Date = DateTime.Now,
                        User = "user1"
                    };
                    //save it in database
                    //AccountEntity.Transactions.Add(depositTransaction);
                    _transactions.Add(withdrawtransaction);
                }
                else
                {

                    throw new Exception("Account Balance is less than amount to be withdrawn");
                }
            }
            return true;
        }
        public virtual decimal CheckAccountBalance()
        {   
            return AccountBalance;
        }
        public virtual List<TransactionDto> SearchTransaction(Utilities.TransactionType typeOftransaction, DateTime startDate, DateTime endDate)
        {            
            
            var transactionDtos = _transactions.Where(a => a.Date > startDate && a.Date < endDate && a.TransactionType == typeOftransaction).Select(b=>new TransactionDto()
            {
                Amount = b.Amount,
                Date= b.Date                
            });

            return transactionDtos.ToList();
        }
    }
}
