namespace Bankservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IniDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        PasswordHash = c.String(),
                        Salt = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        AccountBalance = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Amount = c.Double(nullable: false),
                        Fee = c.Double(nullable: false),
                        SenderCode = c.String(),
                        ReceiverCode = c.String(),
                        Type = c.Int(nullable: false),
                        Message = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
            DropTable("dbo.Accounts");
        }
    }
}
