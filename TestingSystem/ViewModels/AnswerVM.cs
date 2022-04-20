using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Infrastructure;
using TestingSystem.Models.TestModelXml;

namespace TestingSystem.ViewModels
{
    public class AnswerVM : OnPropertyChangedClass
    {
        private readonly AnswerXml _answer;
        private bool _userChoice;

        /// <summary>For binding a checkbox/radiobutton in user control</summary>
        public bool UserChoice
        {
            get => _userChoice;
            set
            {
                _userChoice = value;
                OnPropertyChanged();
            }
        }

        public string Text => _answer.Title;
        public bool IsCorrectUserChoice => UserChoice == _answer.IsRight;
        
        public AnswerVM(AnswerXml answer)
        {
            _answer = answer;
        }
    }
}
