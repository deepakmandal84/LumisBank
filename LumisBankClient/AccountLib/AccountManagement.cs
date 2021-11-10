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
    public static class AccountManagementFactory
    {
        static int accountNumber = 0;
        /*
        public  static bool AddAccount(AccountDto acc)
        {
            var acctype = AccountCollection.AccountTypesEntities.Where(a => a.Code == acc.AccountType.ToString("g")).SingleOrDefault();

            var users = new List<DomainEntities.UserProfileEntity>();
            var user = new DomainEntities.UserProfileEntity()
            {

                FirstName = acc.FirstName,
                LastName = acc.LastName,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsPrimary = true,
                Address = new DomainEntities.AddressEntity()
                {
                    MailingName = acc.FirstName + " " + acc.LastName,
                    Address1 = acc.Add1,
                    City = acc.City,
                    State = acc.State,
                    ZipCode = acc.ZipCode,
                }
            };
            users.Add(user);

            AccountCollection.AccountEntities.Add(new DomainEntities.AccountEntity()
            {
                Id = accountNumber+1,
                AccountName = acc.AccountName,
                AccountType = acctype,
                AccountTypeId = acctype.Id,
                IsActive = true,
                IsJointAccount = acc.IsJointAccount,
                Users = users
            });
            return true;

           
        }
        */

        public static BankAccount Create(AccountType accountType,string name,decimal balance)
        {
            BankAccount acc = null;
            switch (accountType)
            {
                case AccountType.Saving:
                    acc=  new SavingAccount(name, balance);
                    break;
                case AccountType.Current:
                    acc = new CurrentAccount(name, balance);
                    break;
                case AccountType.Student:
                    acc = new StudentAccount(name, balance);
                    break;
                default:
                    break;
            }
            return acc;
        }    
    }
    
}
