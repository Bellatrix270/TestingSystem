using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestingSystem.Models.TestModelXml
{
    public class QuestionXml
    {
        public string Title { get; set; }
        [XmlAttribute]
        public bool IsOnlyOneCorrectAnswer { get; set; }
        [XmlArrayItem("Answer")]
        public List<AnswerXml> Answers { get; set; }

        public QuestionXml()
        {
            
        }
    }
}
