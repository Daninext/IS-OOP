using System;

namespace Banks.Tools
{
    public class SameBankBanksException : BanksException
    {
        public SameBankBanksException()
        {
        }

        public SameBankBanksException(string message)
            : base(message)
        {
        }

        public SameBankBanksException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
