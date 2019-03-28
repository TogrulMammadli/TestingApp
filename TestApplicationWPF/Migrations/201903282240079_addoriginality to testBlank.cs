namespace TestApplicationWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addoriginalitytotestBlank : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TestBlanks", new[] { "Name" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.TestBlanks", "Name", unique: true);
        }
    }
}
