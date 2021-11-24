using System;

namespace IsuExtra.Tools
{
    public class InvalidTimeIsuExtraException : IsuExtraException
    {
        public InvalidTimeIsuExtraException()
        {
        }

        public InvalidTimeIsuExtraException(string message)
            : base(message)
        {
        }

        public InvalidTimeIsuExtraException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
