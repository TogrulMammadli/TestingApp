    using System;
    using System.Data.Entity;
    using System.Linq;
    using TestApplicationWPF.Models;

namespace TestApplicationWPF.DataModel
{
    public class TestContext : DbContext
    {
        public TestContext()
            : base("name=TestContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<AccessLevel> AccessLevels { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cource> Cources { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<PassedTests> PassedTests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TestBlank> TestBlanks { get; set; }
        public DbSet<BestTimeForStudy> bestTimeForStudies { get; set; }
        public DbSet<WantedCourceToStudy> wantedCourceToStudies { get; set; }
      


    


    }
}
