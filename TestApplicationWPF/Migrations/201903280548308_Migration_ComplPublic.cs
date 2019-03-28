namespace TestApplicationWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_ComplPublic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Complexity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Complexity");
        }
    }
}
