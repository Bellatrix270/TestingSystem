using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using TestingSystem.Models.EntityDB;
using TestingSystem.Models.TestModelXml;
using TestingSystem.ViewModels;
using TestingSystem.Views.UserControls;

namespace TestingSystem.Views.Windows
{
    public partial class PassingTestWindow : Window
    {
        public PassingTestWindow()
        {
            InitializeComponent();
            
            TestSystem db = new TestSystem();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestXml));
            List<TestXml> tests = new List<TestXml>();
            int countTest = db.Tests.Count();

            for (int i = 0; i < countTest; i++)
            {
                string remotePath = db.Tests.ToList()[i].FtpPath;

                FtpWebRequest request = WebRequest.Create(@"ftp://37.140.192.191" + remotePath) as FtpWebRequest;

                request.Credentials = new NetworkCredential("u1478686", "wP2fP1bX8hfV9a");
                request.KeepAlive = false;
                request.UseBinary = true;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                Stream str = request.GetResponse().GetResponseStream();
                tests.Add(xmlSerializer.Deserialize(str) as TestXml);
            }

            QuestionsContent content = new QuestionsContent();
            content.Questions = new TestVM(tests[0]).Questions;

            //QuestionsControl.DataContext = content;
        }
    }
}