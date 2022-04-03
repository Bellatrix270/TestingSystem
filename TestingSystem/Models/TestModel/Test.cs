using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Models.TestModel
{
    class Test
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public List<Question> Questions { get; set; }

        public Test(string name, DateTime time, List<Question> questions)
        {
            Name = name;
            Time = time;
            Questions = questions;
        }
    }
}
