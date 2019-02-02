namespace CourseSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publisher : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Courses", "PublisherId");
            AddForeignKey("dbo.Courses", "PublisherId", "dbo.Publishers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "PublisherId", "dbo.Publishers");
            DropIndex("dbo.Courses", new[] { "PublisherId" });
        }
    }
}
