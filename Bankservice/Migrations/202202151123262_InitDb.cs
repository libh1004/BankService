namespace Bankservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Accounts", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Accounts", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
