using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestingSystem.Models.TestModelJson
{
    public class Test
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public ObservableCollection<Question> Questions { get; set; }
    }
}
