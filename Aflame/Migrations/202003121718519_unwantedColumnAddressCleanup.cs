namespace Aflame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unwantedColumnAddressCleanup : DbMigration
    {
        public override void Up()
        {
            DropColumn("Customers", "Address");
        }
        
        public override void Down()
        {
        }
    }
}
