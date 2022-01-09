using System;

namespace Banks.Tools
{
    public class InvalidRegDataBanksException : BanksException
    {
        public InvalidRegDataBanksException()
        {
        }

        public InvalidRegDataBanksException(string message)
            : base(message)
        {
        }

        public InvalidRegDataBanksException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
