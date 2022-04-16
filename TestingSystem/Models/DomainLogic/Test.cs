using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using TestingSystem.Models.EntityDB;
using TestingSystem.Models.TestModelJson;
using TestingSystem.Services;

namespace TestingSystem.Models.DomainLogic
{
    public class Test
    {
        private TestSystem _db = new TestSystem();
        private FtpService _ftpService = new FtpService(@"ftp://37.140.192.191", "u1478686","wP2fP1bX8hfV9a");
        public string Name { get; }
        public List<Question> Questions { get; }

        public Test(string name)
        {
            Name = name;
            string remotePath = _db.Tests.First(t => t.Name == Name).FtpPath;
            
        }
        
        public Question GetQuestion(int questionNumber)
        {
            return new Question();
        }
        
        public static List<TestModelJson.Test> GetAllTest()
        {
            List<TestModelJson.Test> tests = new List<TestModelJson.Test>();
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<TestModelJson.Test>));

            string[] remotePaths = _db.Tests.Select(t => t.FtpPath).ToArray();

            for (int i = 0; i < remotePaths.Length; i++)
            {
                using (Stream ftpStream = _ftpService.GetResponseStream(remotePaths[i], WebRequestMethods.Ftp.DownloadFile))
                    tests.Add(xmlSerializer.Deserialize(ftpStream) as TestModelJson.Test);
            }
            
            return tests;
        }
    }
}