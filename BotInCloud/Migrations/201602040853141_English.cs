namespace BotInCloud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class English : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnglishHomeTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DueDate = c.DateTime(nullable: false),
                        Module = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EnglishHomeTasks");
        }
    }
}
