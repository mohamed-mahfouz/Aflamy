namespace Aflame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBDToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BD", c => c.DateTime());
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BD");
        }
    }
}
