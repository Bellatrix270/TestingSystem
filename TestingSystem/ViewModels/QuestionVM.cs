using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Infrastructure;
using TestingSystem.Models.TestModelXml;

namespace TestingSystem.ViewModels
{
    public abstract class QuestionVM : OnPropertyChangedClass
    {
        private readonly Random _random = new Random();
        private readonly QuestionXml _question;
        public bool IsOnlyOneCorrectAnswer => _question.IsOnlyOneCorrectAnswer;
        public string Text => _question.Title;
        public AnswerVM[] Answers { get; }
        public bool IsCorrectUserChoice => Answers.All(ans => ans.IsCorrectUserChoice);

        protected QuestionVM(QuestionXml question)
        {
            _question = question;
            Answers = _question.Answers.Select(ans => new AnswerVM(ans))
                .OrderBy(x => _random.Next()).ToArray();
        }

        public static QuestionVM Create(QuestionXml question)
        {
            if (question.IsOnlyOneCorrectAnswer)
                return new QuestionSingleAnswerVM(question);

            return new QuestionMultipleAnswersVM(question);
        }

    }
}
