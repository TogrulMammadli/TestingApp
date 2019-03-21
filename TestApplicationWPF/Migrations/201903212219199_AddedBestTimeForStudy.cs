namespace TestApplicationWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBestTimeForStudy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BestTimeForStudies",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        dateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
            AddColumn("dbo.Groups", "LearningTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Groups", "cource_Id", c => c.Int());
            AddColumn("dbo.Users", "Group_Id", c => c.Int());
            CreateIndex("dbo.Groups", "cource_Id");
            CreateIndex("dbo.Users", "Group_Id");
            AddForeignKey("dbo.Groups", "cource_Id", "dbo.Cources", "Id");
            AddForeignKey("dbo.Users", "Group_Id", "dbo.Groups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Groups", "cource_Id", "dbo.Cources");
            DropIndex("dbo.Users", new[] { "Group_Id" });
            DropIndex("dbo.Groups", new[] { "cource_Id" });
            DropColumn("dbo.Users", "Group_Id");
            DropColumn("dbo.Groups", "cource_Id");
            DropColumn("dbo.Groups", "LearningTime");
            DropTable("dbo.BestTimeForStudies");
        }
    }
}
