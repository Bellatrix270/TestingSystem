﻿using System.Collections.Generic;

namespace TestingSystem.Models.TestModelJson
{
    public class Question
    {
        public string Title { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
