namespace TestingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccessLevelRenamed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.АccessLevel", newName: "AccessLevels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AccessLevels", newName: "АccessLevel");
        }
    }
}
