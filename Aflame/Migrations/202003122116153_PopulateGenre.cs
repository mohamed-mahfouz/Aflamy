namespace Aflame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Category) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Category) VALUES ('Action')");
            Sql("INSERT INTO Genres (Category) VALUES ('Family')");
            Sql("INSERT INTO Genres (Category) VALUES ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
