using System.Xml.Serialization;

namespace TestingSystem.Models.TestModelXml
{
    public class AnswerXml
    {
        [XmlText]
        public string Title { get; set; }
        [XmlAttribute]
        public bool IsRight { get; set; }

        public AnswerXml()
        {
            
        }
    }
}
