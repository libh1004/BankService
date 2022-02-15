using Bankservice.Data;
using Bankservice.Entity;
using Bankservice.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.ModelBinding;

namespace Bankservice
{

    public class Service1 : IService
    {
        private MyDbContext db = new MyDbContext();
        private MD5Helper md5Helper = new MD5Helper();
        public bool Register(Account account)
        {
           
            var newAccount = new Account()
            {
                Username = account.Username,
                Password = account.Password,
                PasswordHash = account.PasswordHash,
                Salt = account.Salt,
                Phone = account.Phone, 
                Address = account.Address,
                Email = account.Email,
                AccountBalance = account.AccountBalance,
                Amount = account.Amount,
                Type = account.Type, 
                CreatedAt = account.CreatedAt,
                UpdatedAt = account.UpdatedAt
            };
            db.Accounts.Add(newAccount);
            db.SaveChanges();
            return true;
        }
       public bool Login(string phone, string password)
        {
            var passwordHash = md5Helper.PasswordHash(password);
            var data = db.Accounts.Where(a => a.Phone.Equals(phone) && a.Password.Equals(passwordHash));
            if(data != null)
            {
                HttpContext.Current.Session["Phone"] = data.FirstOrDefault().Phone;
                HttpContext.Current.Session["Password"] = data.FirstOrDefault().Password;
                return true;
            }
            else
            {
                return false;
            }
            return true;
        }
        public bool Logout()
        {
            HttpContext.Current.Session["Phone"] = string.Empty;
            HttpContext.Current.Session["Password"] = string.Empty;
            return true;
        }
        public double Deposit(double amount)
        {
            // kiem tra login thanh cong
            // lay ra so du cua tk do
            // kiem tra amount > 0 -> true -> + amount vao tk
            // NOTICE: tat ca can duoc dua vao 1 transaction.

            double newBalance = 0;
            double getBalance = 10000;
            if (amount > 0)
            {
                newBalance = getBalance + amount;
                return newBalance;
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter again.");
                return newBalance = 0;
            }
        }
        public double Withdrawal(double amount)
        {
            // kiem tra login thanh cong
            // lay ra so du tk
            // kiem tra amount > 0, balance > amount
            // tat ca deu duoc de trong transaction
            double newBalance = 0;
            double getBalance = 10000;
            if (amount > 0 && getBalance > amount)
            {
                newBalance = getBalance - amount;
                Console.WriteLine(newBalance);
                return newBalance;
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter again.");
                return newBalance;
            }
            else if (getBalance < amount)
            {
                Console.WriteLine("The account balance is not enough to make the transaction.");
                return newBalance;
            }
            return newBalance;
        }
        //public double Tranfer(string receiverCode, string senderCode, double amount)
        //{

        //    kiem tra login thanh cong
        //    kiem tra tk nguoi nhan co ton tai khong
        //     lay ra so du cua nguoi gui va nguoi nhan
        //     kiem tra amount > 0, senderBalance > 0, senderBalance > amount
        //     thuc hien +amount vao receiverBalance,
        //               -amount senderBalance.
        //    NOTICE: luu lich su giao dich vao db.
        //     tat ca can duoc dat trong 1 transaction.

        //    if (receiverCode != null)
        //    {
        //        double senderBalance = ;
        //        double receiverBalance = ;
        //        if (amount > 0 && senderBalance > 0 && senderBalance > amount)
        //        {
        //            double newSenderBalance = senderBalance - amount;
        //            double newReceiverBalance = receiverBalance + amount;
        //            Console.WriteLine("Tranfer successful!");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid information. Please enter again.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("User does not exist. Please check again.");
        //    }
        //}
        //public List<Transaction> TransactionHistory(string code)
        //{
        //    List<Transaction> transactionHistories = new List<Transaction>();
        //    // lay tu db senderCode or receiverCode 
        //    var getTransaction = ;
        //    // add transaction vao list

        //}
    }
}
