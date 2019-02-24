namespace CourseSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChannelCourses",
                c => new
                    {
                        ChannelId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChannelId, t.CourseId })
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.ChannelId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChannelCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ChannelCourses", "ChannelId", "dbo.Channels");
            DropForeignKey("dbo.Channels", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Channels", new[] { "UserId" });
            DropIndex("dbo.ChannelCourses", new[] { "CourseId" });
            DropIndex("dbo.ChannelCourses", new[] { "ChannelId" });
            DropTable("dbo.Channels");
            DropTable("dbo.ChannelCourses");
        }
    }
}
