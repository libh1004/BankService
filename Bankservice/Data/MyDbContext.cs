using Bankservice.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bankservice.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyConnectionString")
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}