using Bankservice.Data;
using Bankservice.Entity;
using Bankservice.Helper;
using Bankservice.Service;
using Bankservice.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
        private TransactionService transervice = new TransactionService();
        public bool Register(AccountViewModel account)
        {
            var newAccount = new Account()
            {
                Username = account.Username,
                Password = account.Password,
                PasswordHash = account.ConfirmPassword,
                Salt = account.Salt,
                Phone = account.Phone, 
                Address = account.Address,
                Email = account.Email,
                AccountBalance = account.AccountBalance,
                AccountNumber = transervice.CreateRandomNumbers().ToString(),
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
        public Transaction Transfer(Transaction transaction)
        {
            using(DbContextTransaction trans = db.Database.BeginTransaction())
            {
                try
                {
                    double amount = transaction.Amount;
                    var sender = db.Accounts.FirstOrDefault(a => a.AccountNumber == transaction.SenderCode);
                    var receiver = db.Accounts.FirstOrDefault(a => a.AccountNumber == transaction.ReceiverCode);
                    if (receiver.AccountNumber == null)
                    {
                        Console.WriteLine("User does not exist!");
                    }
                    else
                    {
                        sender.AccountBalance = sender.AccountBalance - amount;
                        receiver.AccountBalance = receiver.AccountBalance + amount;
                        db.SaveChanges();
                        trans.Commit();
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    trans.Rollback();
                    throw ex;
                }
                return transaction;
            }
        }
        public List<Transaction> TransactionHistory(string AccountNumber)
        {
            return db.Transactions.Where(
                m => m.ReceiverCode == AccountNumber
                  || m.SenderCode == AccountNumber).ToList();
        }
    }
}
