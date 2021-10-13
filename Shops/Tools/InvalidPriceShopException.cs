using System;

namespace Shops.Tools
{
    public class InvalidPriceShopException : ShopException
    {
        public InvalidPriceShopException()
        {
        }

        public InvalidPriceShopException(string message)
            : base(message)
        {
        }

        public InvalidPriceShopException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
