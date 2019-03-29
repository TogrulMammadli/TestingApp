using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.DataModel;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.TestBlanksRepository;

namespace TestApplicationWPF.Services.TestServices
{
    public class TestService : ITestService
    {
        private ITestBlankRepository TestBlankRepository = new TestBlankRepository();

        public TestService(ITestBlankRepository testRepository)
        {
            this.TestBlankRepository = testRepository ?? throw new ArgumentNullException(nameof(TestBlankRepository));
        }

        public void CreateTest(string name, string about, string autor, TimeSpan duration, List<Question> questions)
        {
            TestBlankRepository.AddTestBlank(new TestBlank()
            {
                Name = name,
                About = about,
                Autor = autor,
                DurationMin = duration,
                Questions = questions
            });
        }

        public bool CreateTestBlank(TestBlank testBlank)
        {
            return TestBlankRepository.AddTestBlank(testBlank);
        }

        public IEnumerable<TestBlank> GetAllOriginalBlanks()
        {
            return TestContext.Instance.TestBlanks.Where(x => x.original == true);
        }

        public IEnumerable<TestBlank> GetAllTestBlanks()
        {
            return TestBlankRepository.GetAllTestBlanks();
        }

        public IEnumerable<TestBlank> GetAllUsedBlanks()
        {
            return TestContext.Instance.TestBlanks.Where(x=>x.Used==true);
        }

        public IEnumerable<TestBlank> GetUnUsedtestBlanks()
        {
            return TestContext.Instance.TestBlanks.Where(x=>x.Used==false);
        }
    }
}
