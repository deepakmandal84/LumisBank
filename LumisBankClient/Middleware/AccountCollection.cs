using LumisBankClient.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumisBankClient.Middleware
{
    //trying to mimic tat i got this collection from database
    public static class AccountCollection
    {
        public static List<AccountEntity> AccountEntities { get; set; }
        public static List<TransactionType> TransactionTypesEntities { get; set; }
        public static List<AccountTypeEntity> AccountTypesEntities { get; set; }
    }

  
}
