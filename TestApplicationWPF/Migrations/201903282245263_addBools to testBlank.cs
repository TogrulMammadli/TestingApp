namespace TestApplicationWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBoolstotestBlank : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestBlanks", "Used", c => c.Boolean(nullable: false));
            AddColumn("dbo.TestBlanks", "original", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestBlanks", "original");
            DropColumn("dbo.TestBlanks", "Used");
        }
    }
}
