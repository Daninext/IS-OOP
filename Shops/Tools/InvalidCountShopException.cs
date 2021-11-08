using System;

namespace Shops.Tools
{
    public class InvalidCountShopException : ShopException
    {
        public InvalidCountShopException()
        {
        }

        public InvalidCountShopException(string message)
            : base(message)
        {
        }

        public InvalidCountShopException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
