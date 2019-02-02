namespace CourseSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "PublisherCourseId", c => c.String());
            AlterColumn("dbo.Courses", "PublishedOn", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "PublishedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Courses", "PublisherCourseId");
        }
    }
}
