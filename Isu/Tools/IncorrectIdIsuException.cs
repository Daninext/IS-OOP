using System;

namespace Isu.Tools
{
    public class IncorrectIdIsuException : Exception
    {
        public IncorrectIdIsuException()
        {
        }

        public IncorrectIdIsuException(string message)
            : base(message)
        {
        }

        public IncorrectIdIsuException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}