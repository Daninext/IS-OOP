using System;

namespace IsuExtra.Tools
{
    public class TeacherNotFoundIsuExtraException : IsuExtraException
    {
        public TeacherNotFoundIsuExtraException()
        {
        }

        public TeacherNotFoundIsuExtraException(string message)
            : base(message)
        {
        }

        public TeacherNotFoundIsuExtraException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
