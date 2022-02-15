using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Bankservice.Entity
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }
        public string SenderCode { get; set; }
        public string ReceiverCode { get; set; }
        public int Type { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public void ToString()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string typeTransaction = "";
            if (this.Type == 1)
            {
                typeTransaction = "Withdrawal";
            }
            else if (this.Type == 2)
            {
                typeTransaction = "Deposit";
            }
            else if (this.Type == 3)
            {
                typeTransaction = "Tranfer";
            }
            Console.WriteLine($"Code: {Code}, Name: {Type}");
        }
    }
}