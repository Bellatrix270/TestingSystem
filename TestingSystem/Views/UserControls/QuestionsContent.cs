using System;
using TestingSystem.Infrastructure;
using TestingSystem.Infrastructure.Commands;
using TestingSystem.ViewModels;

namespace TestingSystem.Views.UserControls
{
    public class QuestionsContent : OnPropertyChangedClass
    {
        private QuestionVM[] _questions;
        private QuestionVM _currentQuestion;
        private int _indexCurrentQuestion;
        private RelayCommand _jumpQuestionCommand;

        public QuestionVM[] Questions
        {
            get => _questions;
            set
            {
                _questions = value;
                OnPropertyChanged();
                IndexCurrentQuestion = -1;
                ExecuteJumpQuestion(1);
            }
        }

        public QuestionVM CurrentQuestion
        {
            get => _currentQuestion;
            set
            {
                _currentQuestion = value;
                OnPropertyChanged();
            }
        }

        private int IndexCurrentQuestion
        {
            get => _indexCurrentQuestion;
            set
            {
                _indexCurrentQuestion = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand JumpQuestionCommand => _jumpQuestionCommand ?? 
                                                   (_jumpQuestionCommand = new RelayCommand(ExecuteJumpQuestion,
                                                       CanExecuteJumpQuestionCommand));

        private bool CanExecuteJumpQuestionCommand(object parameter)
            => parameter != null && int.TryParse(parameter.ToString(), out int convertedParam) &&
               IndexCurrentQuestion + convertedParam >= 0 && IndexCurrentQuestion + convertedParam < Questions.Length;

        private void ExecuteJumpQuestion(object parameter)
        {
            int newIndex = IndexCurrentQuestion + Convert.ToInt32(parameter);

            if (newIndex != IndexCurrentQuestion)
            {
                IndexCurrentQuestion = newIndex;
                CurrentQuestion = Questions[IndexCurrentQuestion];
            }
        }
    }
}