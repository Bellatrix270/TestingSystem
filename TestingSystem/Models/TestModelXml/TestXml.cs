using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace TestingSystem.Models.TestModelXml
{
    [XmlRoot("Test")]
    public class TestXml
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        [XmlArrayItem("Question")]
        public ObservableCollection<QuestionXml> Questions { get; set; }

        public TestXml()
        {
            
        }
    }
}
