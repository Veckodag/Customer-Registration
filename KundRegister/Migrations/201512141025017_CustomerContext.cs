namespace KundRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CompanyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CompanyName");
        }
    }
}
