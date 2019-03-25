using System;
using System.Data.Entity;
using System.Linq;
using TestApplicationWPF.Models;

namespace TestApplicationWPF.DataModel
{

    public class TestContext : DbContext
    {
        private static TestContext _singletone = null;
        private static object o = new object();
        public static TestContext Instance
        {
            get
            {
                if (_singletone == null)
                {
                    lock (o)
                    {
                        if (_singletone == null)
                        {
                            _singletone = new TestContext();
                        }
                    }

                }
                return _singletone;
            }

        }

        public TestContext()
            : base("name=TestContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<AccessLevel> AccessLevels { get; set; }
        public DbSet<CorrectAnswer> correctAnswers { get; set; }
        public DbSet<WrongAnswer> wrongAnswers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cource> Cources { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Exams> PassedTests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TestBlank> TestBlanks { get; set; }
        public DbSet<BestTimeForStudy> bestTimeForStudies { get; set; }
        public DbSet<WantedCourceToStudy> wantedCourceToStudies { get; set; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            TestContext._singletone = null;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
