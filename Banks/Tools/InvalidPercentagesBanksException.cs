using System;

namespace Banks.Tools
{
    public class InvalidPercentagesBanksException : BanksException
    {
        public InvalidPercentagesBanksException()
        {
        }

        public InvalidPercentagesBanksException(string message)
            : base(message)
        {
        }

        public InvalidPercentagesBanksException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
