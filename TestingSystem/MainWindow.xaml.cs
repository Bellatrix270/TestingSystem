using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using TestingSystem.Models.EntityDB;
using Test = TestingSystem.Models.TestModelJson.Test;

namespace TestingSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TestSystem db = new TestSystem();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Test));
            List<Test> tests = new List<Test>();
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
                tests.Add(xmlSerializer.Deserialize(str) as Test);
            }

            TreeViewTest.ItemsSource = tests;
            
            XmlDataProvider xmlDataProvider = new XmlDataProvider();

            //using (FileStream fs = new FileStream("Test.xml", FileMode.OpenOrCreate))
            //{
            //    xmlSerializer.Serialize(fs, tests);
            //}
            
        }
    }
}
