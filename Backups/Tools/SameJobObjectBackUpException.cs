using System;

namespace Backups.Tools
{
    public class SameJobObjectBackUpException : BackUpException
    {
        public SameJobObjectBackUpException()
        {
        }

        public SameJobObjectBackUpException(string message)
            : base(message)
        {
        }

        public SameJobObjectBackUpException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
