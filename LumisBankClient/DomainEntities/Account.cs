using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumisBankClient.DomainEntities
{
    public class AccountEntity : BaseEntity
    {
        public string AccountName { get; set; }
        public bool IsJointAccount { get; set; }
        public bool IsActive { get; set; }
        public List<UserProfileEntity> Users{get;set;}
        public int AccountTypeId { get; set; }
        public AccountTypeEntity AccountType { get; set; }
        public List<Transaction> Transactions { get; set; }
    }

    public class UserProfileEntity:BaseEntity
    {
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressEntity Address { get; set; }
    }
    public class AddressEntity:BaseEntity
    {
        public string MailingName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

    }
    

    public class AccountTypeEntity : BaseLookUp
    {
        
    }

}
