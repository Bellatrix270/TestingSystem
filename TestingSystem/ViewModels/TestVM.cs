using System;
using System.Linq;
using TestingSystem.Infrastructure;
using TestingSystem.Models.TestModelXml;

namespace TestingSystem.ViewModels
{
    public class TestVM : OnPropertyChangedClass
    {
        private readonly Random _random = new Random();
        private readonly TestXml _test;
        public string Name => _test.Name;
        public QuestionVM[] Questions { get; }
        public int CountRightAnswers => Questions.Count(q => q.IsCorrectUserChoice);

        public TestVM(TestXml test)
        {
            _test = test;
            Questions = test.Questions.Select(QuestionVM.Create)
                .OrderBy(x => _random.Next()).ToArray();
        }
    }
}