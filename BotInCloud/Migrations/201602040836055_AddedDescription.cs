namespace BotInCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignments", "Description");
        }
    }
}
