using LumisBankClient.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumisBankClient.DTO
{
    public class AccountDto
    {
        public string AccountName { get; set; }
        public bool IsJointAccount { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Add1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Amount { get; set; }
    }
}
