using System;

namespace Banks.Tools
{
    public class AccountNotExistsBanksException : BanksException
    {
        public AccountNotExistsBanksException()
        {
        }

        public AccountNotExistsBanksException(string message)
            : base(message)
        {
        }

        public AccountNotExistsBanksException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
