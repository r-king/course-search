namespace CourseSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publicherImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publishers", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publishers", "ImageUrl");
        }
    }
}
