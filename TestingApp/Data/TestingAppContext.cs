using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp.Models;

namespace TestingApp.Data
{
   public class TestingAppContext : DbContext
    {
        public TestingAppContext() : base()
        {

        }

        public DbSet<АccessLevel> АccessLevels { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cource> Cources { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<PassedTests> PassedTests { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TestBlank> TestBlanks { get; set; }
        public DbSet<User> Users { get; set; }





    }
}
