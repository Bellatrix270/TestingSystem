using TestingSystem.Models.TestModelXml;

namespace TestingSystem.Exception
{
    public class TestException : System.Exception
    {
        public QuestionXml ErrorQuestion { get; }
        public TestExceptionEnum TypeError { get; }

        public TestException(QuestionXml errorQuestion, TestExceptionEnum typeError)
        {
            ErrorQuestion = errorQuestion;
            TypeError = typeError;
        }
        
        public TestException(string message, QuestionXml errorQuestion, TestExceptionEnum typeError)
            : base(message)
        {
            ErrorQuestion = errorQuestion;
            TypeError = typeError;
        }
        
        public TestException(string message, System.Exception innerException, QuestionXml errorQuestion, TestExceptionEnum typeError)
            : base(message, innerException)
        {
            ErrorQuestion = errorQuestion;
            TypeError = typeError;
        }
    }
}