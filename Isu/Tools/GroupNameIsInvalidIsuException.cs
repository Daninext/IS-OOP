using System;

namespace Isu.Tools
{
    public class GroupNameIsInvalidIsuException : IsuException
    {
        public GroupNameIsInvalidIsuException()
        {
        }

        public GroupNameIsInvalidIsuException(string message)
            : base(message)
        {
        }

        public GroupNameIsInvalidIsuException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}