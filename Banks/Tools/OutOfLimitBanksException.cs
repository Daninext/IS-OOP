using System;

namespace Banks.Tools
{
    public class OutOfLimitBanksException : BanksException
    {
        public OutOfLimitBanksException()
        {
        }

        public OutOfLimitBanksException(string message)
            : base(message)
        {
        }

        public OutOfLimitBanksException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
