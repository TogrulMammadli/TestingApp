namespace TestApplicationWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Patronymic", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 40));
            AlterColumn("dbo.Users", "Login", c => c.String(maxLength: 40));
            CreateIndex("dbo.Users", "Email", unique: true);
            CreateIndex("dbo.Users", "Login", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.Users", new[] { "Email" });
            AlterColumn("dbo.Users", "Login", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Surname", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "Patronymic");
        }
    }
}
