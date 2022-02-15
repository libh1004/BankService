using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bankservice.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public double AccountBalance { get; set; }
        public double Amount { get; set; }
        //public int Status { get; set; }
        public int Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public override string ToString()
        {
            return $" Username {Username}, Phone {Phone}";
        }
    }
}