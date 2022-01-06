using System;

namespace Backups.Tools
{
    public class JobObjectNotFoundBackUpException : BackUpException
    {
        public JobObjectNotFoundBackUpException()
        {
        }

        public JobObjectNotFoundBackUpException(string message)
            : base(message)
        {
        }

        public JobObjectNotFoundBackUpException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
