using System;

namespace Isu.Tools
{
    public class GroupIsFullIsuException : IsuException
    {
        public GroupIsFullIsuException()
        {
        }

        public GroupIsFullIsuException(string message)
            : base(message)
        {
        }

        public GroupIsFullIsuException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}