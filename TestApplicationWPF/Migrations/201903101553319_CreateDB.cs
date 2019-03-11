namespace TestApplicationWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Image = c.Binary(),
                        Question_Id = c.Int(),
                        Question_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id1)
                .Index(t => t.Question_Id)
                .Index(t => t.Question_Id1);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Cources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        duration = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PassedTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Blank_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestBlanks", t => t.Blank_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Blank_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TestBlanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DurationMin = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Image = c.Binary(),
                        subject_Id = c.Int(),
                        TestBlank_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.subject_Id)
                .ForeignKey("dbo.TestBlanks", t => t.TestBlank_Id)
                .Index(t => t.subject_Id)
                .Index(t => t.TestBlank_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 20),
                        Patronymic = c.String(nullable: false, maxLength: 20),
                        DateOfBirth = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(maxLength: 40),
                        Password = c.String(),
                        Login = c.String(maxLength: 40),
                        İmage = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true)
                .Index(t => t.Login, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PassedTests", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AccessLevels", "User_Id", "dbo.Users");
            DropForeignKey("dbo.PassedTests", "Blank_Id", "dbo.TestBlanks");
            DropForeignKey("dbo.Questions", "TestBlank_Id", "dbo.TestBlanks");
            DropForeignKey("dbo.Questions", "subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Answers", "Question_Id1", "dbo.Questions");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Subjects", new[] { "Name" });
            DropIndex("dbo.Questions", new[] { "TestBlank_Id" });
            DropIndex("dbo.Questions", new[] { "subject_Id" });
            DropIndex("dbo.TestBlanks", new[] { "Name" });
            DropIndex("dbo.PassedTests", new[] { "User_Id" });
            DropIndex("dbo.PassedTests", new[] { "Blank_Id" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropIndex("dbo.Answers", new[] { "Question_Id1" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.AccessLevels", new[] { "User_Id" });
            DropIndex("dbo.AccessLevels", new[] { "Name" });
            DropTable("dbo.Users");
            DropTable("dbo.Subjects");
            DropTable("dbo.Questions");
            DropTable("dbo.TestBlanks");
            DropTable("dbo.PassedTests");
            DropTable("dbo.Groups");
            DropTable("dbo.Cources");
            DropTable("dbo.Categories");
            DropTable("dbo.Answers");
            DropTable("dbo.AccessLevels");
        }
    }
}
