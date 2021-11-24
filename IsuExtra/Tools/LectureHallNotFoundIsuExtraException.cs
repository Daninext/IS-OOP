using System;

namespace IsuExtra.Tools
{
    public class LectureHallNotFoundIsuExtraException : IsuExtraException
    {
        public LectureHallNotFoundIsuExtraException()
        {
        }

        public LectureHallNotFoundIsuExtraException(string message)
            : base(message)
        {
        }

        public LectureHallNotFoundIsuExtraException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
