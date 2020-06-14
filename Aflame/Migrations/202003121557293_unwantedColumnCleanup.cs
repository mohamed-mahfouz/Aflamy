namespace Aflame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unwantedColumnCleanup : DbMigration
    {
        public override void Up()
        {
            DropColumn("Customers", "Birthdate");
        }
        
        public override void Down()
        {
            
        }
    }
}
