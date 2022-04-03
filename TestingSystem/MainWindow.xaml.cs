using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using TestingSystem.Models.TestModel;

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
            //Model.User user = new Model.TestSystem().Users.First();

            List<Question> questions = new List<Question>();

            List<Answer> answers = new List<Answer>();
            answers.Add(new Answer("yes", false));
            answers.Add(new Answer("no", false));
            answers.Add(new Answer("maybe", true));

            questions.Add(new Question("Кто ты таков?", answers));

            Test OPBD = new Test("OPBD", DateTime.Now, questions);

            bool isCorrectAnswer = OPBD.Questions[0].Answers[0].IsTrue;
        }
    }
}
