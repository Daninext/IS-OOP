using System;

namespace Shops.Tools
{
    public class InvalidIdShopException : ShopException
    {
        public InvalidIdShopException()
        {
        }

        public InvalidIdShopException(string message)
            : base(message)
        {
        }

        public InvalidIdShopException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
