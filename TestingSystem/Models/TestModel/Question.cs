using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Models.TestModel
{
    class Question
    {
        public string Title { get; set; }
        public List<Answer> Answers { get; set; }

        public Question(string title, List<Answer> answers)
        {
            Title = title;
            Answers = answers;
        }
    }
}
