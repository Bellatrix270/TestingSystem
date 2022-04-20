using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using TestingSystem.Exception;
using TestingSystem.Models.EntityDB;
using TestingSystem.Models.TestModelXml;
using TestingSystem.Services;

namespace TestingSystem.Models.DomainLogic
{
    public class Test
    {
        private TestSystem _db = new TestSystem();
        private FtpService _ftpService = new FtpService(@"ftp://37.140.192.191", "u1478686","wP2fP1bX8hfV9a");
        public string Name { get; }
        public ObservableCollection<QuestionXml> Questions { get; }

        public Test(string name)
        {
            Name = name;
            string remotePath = _db.Tests.First(t => t.Name == Name).FtpPath;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestXml));

            using (Stream ftpStream = _ftpService.GetResponseStream(remotePath, WebRequestMethods.Ftp.DownloadFile))
                Questions = (xmlSerializer.Deserialize(ftpStream) as TestXml)?.Questions;

            foreach (QuestionXml question in Questions)
            {
                switch (ValidateAnswer(question.Answers, question.IsOnlyOneCorrectAnswer))
                {
                    case TestExceptionEnum.NoRight:
                        throw new TestException("Question not contains correct answers", question,
                            TestExceptionEnum.NoRight);
                    case TestExceptionEnum.NotOnlyOne:
                        throw new TestException("Question must contains 1 correct answer", question,
                            TestExceptionEnum.NotOnlyOne);
                    case TestExceptionEnum.InvalidIsOnlyOne:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private TestExceptionEnum? ValidateAnswer(IEnumerable<AnswerXml> answers, bool isOnlyOneCorrectAnswer)
        {
            int countCorrectAnswer = answers.Count(a => a.IsRight);

            if (countCorrectAnswer == 0)
                return TestExceptionEnum.NoRight;
            if (countCorrectAnswer != 1 && isOnlyOneCorrectAnswer)
                return TestExceptionEnum.NotOnlyOne;

            return null;
        }

        public static List<TestXml> GetAllTest()
        {
            List<TestXml> tests = new List<TestXml>();
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestModelXml.TestXml));
            FtpService ftpService = new FtpService(@"ftp://37.140.192.191", "u1478686","wP2fP1bX8hfV9a");

            string[] remotePaths = new TestSystem().Tests.Select(t => t.FtpPath).ToArray();

            for (int i = 0; i < remotePaths.Length; i++)
            {
                using (Stream ftpStream = ftpService.GetResponseStream(remotePaths[i], WebRequestMethods.Ftp.DownloadFile))
                    tests.Add(xmlSerializer.Deserialize(ftpStream) as TestModelXml.TestXml);
            }
            
            return tests;
        }
    }
}