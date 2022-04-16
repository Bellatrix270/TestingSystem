using System;
using System.Collections.Generic;

namespace TestingSystem.Models.TestModelJson
{
    public class Test
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public List<Question> Questions { get; set; }
    }
}
