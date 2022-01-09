using System;

namespace Banks.Tools
{
    public class InvalidMoneyCountBanksException : BanksException
    {
        public InvalidMoneyCountBanksException()
        {
        }

        public InvalidMoneyCountBanksException(string message)
            : base(message)
        {
        }

        public InvalidMoneyCountBanksException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
