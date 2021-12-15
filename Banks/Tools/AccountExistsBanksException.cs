using System;

namespace Banks.Tools
{
    public class AccountExistsBanksException : BanksException
    {
        public AccountExistsBanksException()
        {
        }

        public AccountExistsBanksException(string message)
            : base(message)
        {
        }

        public AccountExistsBanksException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
