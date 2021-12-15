using System;

namespace Banks.Tools
{
    public class WithdrawDenyBanksException : BanksException
    {
        public WithdrawDenyBanksException()
        {
        }

        public WithdrawDenyBanksException(string message)
            : base(message)
        {
        }

        public WithdrawDenyBanksException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
