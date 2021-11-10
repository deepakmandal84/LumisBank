using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumisBankClient.DomainEntities
{
    public class Transaction :BaseEntity
    {
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int  TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
        public string UserName { get; set; }
        public decimal LastAccountBalance { get; set; }

    }
    public class TransactionType : BaseLookUp
    {

    }
}
