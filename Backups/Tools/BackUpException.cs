using System;

namespace Backups.Tools
{
    public class BackUpException : Exception
    {
        public BackUpException()
        {
        }

        public BackUpException(string message)
            : base(message)
        {
        }

        public BackUpException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
