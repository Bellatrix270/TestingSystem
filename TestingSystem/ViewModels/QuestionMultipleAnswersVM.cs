using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Exception;
using TestingSystem.Models.TestModelXml;

namespace TestingSystem.ViewModels
{
    class QuestionMultipleAnswersVM : QuestionVM
    {
        public QuestionMultipleAnswersVM(QuestionXml question) : base(question)
        {
            if (IsOnlyOneCorrectAnswer)
                throw new TestException($"Invalid property value {nameof(IsOnlyOneCorrectAnswer)}", question,
                    TestExceptionEnum.InvalidIsOnlyOne);
        }
    }
}
