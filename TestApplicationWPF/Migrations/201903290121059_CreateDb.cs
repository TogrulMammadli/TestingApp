namespace TestApplicationWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
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
                "dbo.CorrectAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Complexity = c.Int(nullable: false),
                        Image = c.Binary(),
                        subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.subject_Id)
                .Index(t => t.subject_Id);
            
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
                "dbo.TestBlanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        About = c.String(),
                        Autor = c.String(),
                        DurationMin = c.Time(nullable: false, precision: 7),
                        Used = c.Boolean(nullable: false),
                        original = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WrongAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Exams",
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
                "dbo.StudentAnwsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Exams_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.Exams_Id)
                .Index(t => t.Exams_Id);
            
            CreateTable(
                "dbo.Ans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        An = c.String(),
                        StudentAnwsers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentAnwsers", t => t.StudentAnwsers_Id)
                .Index(t => t.StudentAnwsers_Id);
            
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
            
            CreateTable(
                "dbo.QuestionCorrectAnswers",
                c => new
                    {
                        Question_Id = c.Int(nullable: false),
                        CorrectAnswer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Id, t.CorrectAnswer_Id })
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .ForeignKey("dbo.CorrectAnswers", t => t.CorrectAnswer_Id, cascadeDelete: true)
                .Index(t => t.Question_Id)
                .Index(t => t.CorrectAnswer_Id);
            
            CreateTable(
                "dbo.TestBlankQuestions",
                c => new
                    {
                        TestBlank_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestBlank_Id, t.Question_Id })
                .ForeignKey("dbo.TestBlanks", t => t.TestBlank_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.TestBlank_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.WrongAnswerQuestions",
                c => new
                    {
                        WrongAnswer_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WrongAnswer_Id, t.Question_Id })
                .ForeignKey("dbo.WrongAnswers", t => t.WrongAnswer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.WrongAnswer_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WantedCourceToStudies", "Cource_Id", "dbo.Cources");
            DropForeignKey("dbo.Exams", "User_Id", "dbo.Users");
            DropForeignKey("dbo.StudentAnwsers", "Exams_Id", "dbo.Exams");
            DropForeignKey("dbo.Ans", "StudentAnwsers_Id", "dbo.StudentAnwsers");
            DropForeignKey("dbo.Exams", "Blank_Id", "dbo.TestBlanks");
            DropForeignKey("dbo.Users", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Groups", "cource_Id", "dbo.Cources");
            DropForeignKey("dbo.WrongAnswerQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.WrongAnswerQuestions", "WrongAnswer_Id", "dbo.WrongAnswers");
            DropForeignKey("dbo.TestBlankQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.TestBlankQuestions", "TestBlank_Id", "dbo.TestBlanks");
            DropForeignKey("dbo.Questions", "subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.QuestionCorrectAnswers", "CorrectAnswer_Id", "dbo.CorrectAnswers");
            DropForeignKey("dbo.QuestionCorrectAnswers", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.UserAccessLevels", "AccessLevel_Id", "dbo.AccessLevels");
            DropForeignKey("dbo.UserAccessLevels", "User_Id", "dbo.Users");
            DropIndex("dbo.WrongAnswerQuestions", new[] { "Question_Id" });
            DropIndex("dbo.WrongAnswerQuestions", new[] { "WrongAnswer_Id" });
            DropIndex("dbo.TestBlankQuestions", new[] { "Question_Id" });
            DropIndex("dbo.TestBlankQuestions", new[] { "TestBlank_Id" });
            DropIndex("dbo.QuestionCorrectAnswers", new[] { "CorrectAnswer_Id" });
            DropIndex("dbo.QuestionCorrectAnswers", new[] { "Question_Id" });
            DropIndex("dbo.UserAccessLevels", new[] { "AccessLevel_Id" });
            DropIndex("dbo.UserAccessLevels", new[] { "User_Id" });
            DropIndex("dbo.WantedCourceToStudies", new[] { "Cource_Id" });
            DropIndex("dbo.Ans", new[] { "StudentAnwsers_Id" });
            DropIndex("dbo.StudentAnwsers", new[] { "Exams_Id" });
            DropIndex("dbo.Exams", new[] { "User_Id" });
            DropIndex("dbo.Exams", new[] { "Blank_Id" });
            DropIndex("dbo.Groups", new[] { "cource_Id" });
            DropIndex("dbo.Subjects", new[] { "Name" });
            DropIndex("dbo.Questions", new[] { "subject_Id" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "Group_Id" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.AccessLevels", new[] { "Name" });
            DropTable("dbo.WrongAnswerQuestions");
            DropTable("dbo.TestBlankQuestions");
            DropTable("dbo.QuestionCorrectAnswers");
            DropTable("dbo.UserAccessLevels");
            DropTable("dbo.WantedCourceToStudies");
            DropTable("dbo.Ans");
            DropTable("dbo.StudentAnwsers");
            DropTable("dbo.Exams");
            DropTable("dbo.Groups");
            DropTable("dbo.Cources");
            DropTable("dbo.WrongAnswers");
            DropTable("dbo.TestBlanks");
            DropTable("dbo.Subjects");
            DropTable("dbo.Questions");
            DropTable("dbo.CorrectAnswers");
            DropTable("dbo.Categories");
            DropTable("dbo.BestTimeForStudies");
            DropTable("dbo.Users");
            DropTable("dbo.AccessLevels");
        }
    }
}
