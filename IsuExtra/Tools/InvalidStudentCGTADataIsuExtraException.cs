using System;
namespace IsuExtra.Tools
{
    public class InvalidStudentCGTADataIsuExtraException : IsuExtraException
    {
        public InvalidStudentCGTADataIsuExtraException()
        {
        }

        public InvalidStudentCGTADataIsuExtraException(string message)
            : base(message)
        {
        }

        public InvalidStudentCGTADataIsuExtraException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
