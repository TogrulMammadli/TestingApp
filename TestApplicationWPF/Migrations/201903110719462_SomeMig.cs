namespace TestApplicationWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestBlanks", "About", c => c.String());
            AddColumn("dbo.TestBlanks", "Autor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestBlanks", "Autor");
            DropColumn("dbo.TestBlanks", "About");
        }
    }
}
