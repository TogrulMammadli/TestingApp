namespace TestApplicationWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeMigration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cources", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cources", new[] { "Name" });
        }
    }
}
