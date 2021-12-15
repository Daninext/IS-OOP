using System;

namespace Banks.Tools
{
    public class SameClientBanksException : BanksException
    {
        public SameClientBanksException()
        {
        }

        public SameClientBanksException(string message)
            : base(message)
        {
        }

        public SameClientBanksException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
