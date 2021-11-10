using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumisBankClient.Utilities;
namespace LumisBankClient.DTO
{
    public class TransactionDto
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string User { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
