using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplicationWPF.Models;
using TestApplicationWPF.Repository.TestBlanksRepository;

namespace TestApplicationWPF.Services.TestServices
{
    public class TestService : ITestService
    {
        public ITestBlankRepository TestBlankRepository = new TestBlankRepository();

        public TestService(ITestBlankRepository testRepository)
        {
            this.TestBlankRepository = testRepository ?? throw new ArgumentNullException(nameof(TestBlankRepository));
        }

        public void CreateTest(string name,string about,string autor,TimeSpan duration,List<Question>questions) {
            TestBlankRepository.AddTestBlank(new TestBlank() {
            Name=name,
            About=about,
            Autor=autor,
            DurationMin=duration,
            Questions=questions});
        }

        public IEnumerable<TestBlank> GetAllTestBlanks()
        {
            return TestBlankRepository.GetAllTestBlanks();
        }
    }
}
