namespace TestApplicationWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
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
                        Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .Index(t => t.Email, unique: true)
                .Index(t => t.Login, unique: true)
                .Index(t => t.Group_Id);
            
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
                "dbo.BestTimeForStudies",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        dateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.userId);
            
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
                        LearningTime = c.DateTime(nullable: false),
                        cource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cources", t => t.cource_Id)
                .Index(t => t.cource_Id);
            
            CreateTable(
                "dbo.PassedTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
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
                        About = c.String(),
                        Autor = c.String(),
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
                "dbo.WantedCourceToStudies",
                c => new
                    {
                        StudetnId = c.Int(nullable: false, identity: true),
                        Cource_Id = c.Int(),
                    })
                .PrimaryKey(t => t.StudetnId)
                .ForeignKey("dbo.Cources", t => t.Cource_Id)
                .Index(t => t.Cource_Id);
            
            CreateTable(
                "dbo.UserAccessLevels",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        AccessLevel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.AccessLevel_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.AccessLevels", t => t.AccessLevel_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.AccessLevel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WantedCourceToStudies", "Cource_Id", "dbo.Cources");
            DropForeignKey("dbo.PassedTests", "User_Id", "dbo.Users");
            DropForeignKey("dbo.PassedTests", "Blank_Id", "dbo.TestBlanks");
            DropForeignKey("dbo.Questions", "TestBlank_Id", "dbo.TestBlanks");
            DropForeignKey("dbo.Questions", "subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Answers", "Question_Id1", "dbo.Questions");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Users", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Groups", "cource_Id", "dbo.Cources");
            DropForeignKey("dbo.UserAccessLevels", "AccessLevel_Id", "dbo.AccessLevels");
            DropForeignKey("dbo.UserAccessLevels", "User_Id", "dbo.Users");
            DropIndex("dbo.UserAccessLevels", new[] { "AccessLevel_Id" });
            DropIndex("dbo.UserAccessLevels", new[] { "User_Id" });
            DropIndex("dbo.WantedCourceToStudies", new[] { "Cource_Id" });
            DropIndex("dbo.Subjects", new[] { "Name" });
            DropIndex("dbo.Questions", new[] { "TestBlank_Id" });
            DropIndex("dbo.Questions", new[] { "subject_Id" });
            DropIndex("dbo.TestBlanks", new[] { "Name" });
            DropIndex("dbo.PassedTests", new[] { "User_Id" });
            DropIndex("dbo.PassedTests", new[] { "Blank_Id" });
            DropIndex("dbo.Groups", new[] { "cource_Id" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropIndex("dbo.Answers", new[] { "Question_Id1" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            DropIndex("dbo.Users", new[] { "Group_Id" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.AccessLevels", new[] { "Name" });
            DropTable("dbo.UserAccessLevels");
            DropTable("dbo.WantedCourceToStudies");
            DropTable("dbo.Subjects");
            DropTable("dbo.Questions");
            DropTable("dbo.TestBlanks");
            DropTable("dbo.PassedTests");
            DropTable("dbo.Groups");
            DropTable("dbo.Cources");
            DropTable("dbo.Categories");
            DropTable("dbo.BestTimeForStudies");
            DropTable("dbo.Answers");
            DropTable("dbo.Users");
            DropTable("dbo.AccessLevels");
        }
    }
}
