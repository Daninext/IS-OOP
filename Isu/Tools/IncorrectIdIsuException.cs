using System;

namespace Isu.Tools
{
    public class IncorrectIdIsuException : IsuException
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