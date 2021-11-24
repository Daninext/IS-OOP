using System;

namespace IsuExtra.Tools
{
    public class CGTANotFoundIsuExtraException : IsuExtraException
    {
        public CGTANotFoundIsuExtraException()
        {
        }

        public CGTANotFoundIsuExtraException(string message)
            : base(message)
        {
        }

        public CGTANotFoundIsuExtraException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
