namespace CourseSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class channelDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Channels", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Channels", "Description");
        }
    }
}
