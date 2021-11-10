using LumisBankClient.AccountLib;
using LumisBankClient.DTO;
using System;
using System.Collections.Generic;

namespace LumisBankClient
{
    //Started 5:45 PM
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AccountDto accountDto1 = new AccountDto()
            //{
            //    AccountName ="Deepak CC",
            //    AccountType = Utilities.AccountType.Saving,
            //    Add1 = "5880 Sycamore dr",
            //    City="Pleasanton",
            //    Amount=1000,
            //    FirstName="Deepak",
            //    IsActive=true,
            //    IsJointAccount=false,
            //    LastName="Mandal",
            //    State="CA",
            //    ZipCode="95391"
            //};
            //AccountLib.AccountManagement.AddAccount(accountDto1);
            List<BankAccount> bankAccounts = new List<BankAccount>();
            var acc1= AccountManagementFactory.Create(Utilities.AccountType.Current, "Deepak", 1000);
            Console.WriteLine(acc1.CheckAccountBalance().ToString());
            bankAccounts.Add(acc1);

            var savingsacc = AccountManagementFactory.Create(Utilities.AccountType.Current, "John", 500);
            bankAccounts.Add(savingsacc);
            Console.WriteLine(savingsacc.CheckAccountBalance().ToString());
            Console.WriteLine(savingsacc.WithDrawFunds(100).ToString());
            Console.WriteLine(savingsacc.WithDrawFunds(200).ToString());
            Console.WriteLine(savingsacc.WithDrawFunds(150).ToString());
            Console.WriteLine(savingsacc.CheckAccountBalance().ToString());
            Console.WriteLine(savingsacc.WithDrawFunds(30).ToString());
            Console.WriteLine(savingsacc.CheckAccountBalance().ToString());
            Console.WriteLine(savingsacc.CalculateInterestRate().ToString());


            var sacc = AccountManagementFactory.Create(Utilities.AccountType.Saving, "TOM", 500);
            bankAccounts.Add(sacc);
            Console.WriteLine(sacc.CheckAccountBalance().ToString());
            Console.WriteLine(sacc.WithDrawFunds(100).ToString());
            Console.WriteLine(sacc.WithDrawFunds(200).ToString());
            Console.WriteLine(sacc.WithDrawFunds(150).ToString());
            Console.WriteLine(sacc.CheckAccountBalance().ToString());
            Console.WriteLine(sacc.CalculateInterestRate().ToString());
            Console.WriteLine(sacc.WithDrawFunds(30).ToString());
            Console.WriteLine(sacc.CheckAccountBalance().ToString());
            Console.WriteLine(sacc.CalculateInterestRate().ToString());
            //Console.WriteLine(sacc.WithDrawFunds(5000).ToString());
            Console.WriteLine(sacc.DepositFunds(5000).ToString());
            Console.WriteLine(sacc.CalculateInterestRate().ToString());
            Console.WriteLine(sacc.DepositFunds(6000).ToString());
            Console.WriteLine(sacc.CalculateInterestRate().ToString());

            //testcase for student account
            var studentcc = AccountManagementFactory.Create(Utilities.AccountType.Student, "TOM", 2000);
            Console.WriteLine(studentcc.WithDrawFunds(100).ToString());
            Console.WriteLine(studentcc.WithDrawFunds(200).ToString());
            Console.WriteLine(studentcc.WithDrawFunds(150).ToString());
            Console.WriteLine(studentcc.DepositFunds(5000).ToString());
            Console.WriteLine(studentcc.WithDrawFunds(300).ToString());
            Console.WriteLine(studentcc.WithDrawFunds(75).ToString());
            Console.WriteLine(studentcc.WithDrawFunds(95).ToString());



        }
    }
    
   

   
   
   
   
}
