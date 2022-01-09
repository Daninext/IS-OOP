using System;

namespace Banks.Tools
{
    public class PercentNotExistsBanksException : BanksException
    {
        public PercentNotExistsBanksException()
        {
        }

        public PercentNotExistsBanksException(string message)
            : base(message)
        {
        }

        public PercentNotExistsBanksException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
