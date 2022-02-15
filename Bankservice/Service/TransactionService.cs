using Bankservice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankservice.Service
{
    public class TransactionService
    {
        private Random _random = new Random();
        public int CreateRandomNumbers()
        {
            return int.Parse(_random.Next(10, 99).ToString() + _random.Next(10, 99).ToString() +
                _random.Next(100, 999).ToString());
        }
        //public Account CheckUserExist(string accountNumber)
        //{
        //    Account account = null;
        //    try
        //    {
        //        cmd.CommandText = $"select * from account where AccountNumber = '{accountNumber}'";
        //        var result = cmd.ExecuteReader();
        //        if (result.HasRows)
        //        {
        //            while (result.Read())
        //            {
        //                account = new Account()
        //                {
        //                    AccountNumber = result["AccountNumber"].ToString(),
        //                    Phone = result["Phone"].ToString(),
        //                };
        //            }
        //        }
        //        result.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Connection error!");
        //    }
        //    return account;
        //}
    }
}