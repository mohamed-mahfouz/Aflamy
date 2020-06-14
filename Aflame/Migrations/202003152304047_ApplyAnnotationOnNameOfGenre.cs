namespace Aflame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationOnNameOfGenre : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Category", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Category", c => c.String());
        }
    }
}
