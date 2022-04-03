using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Models.TestModel
{
    class Answer
    {
        public string Title { get; set; }
        public bool IsTrue { get; set; }

        public Answer(string title, bool isTrue)
        {
            Title = title;
            IsTrue = isTrue;
        }
    }
}
