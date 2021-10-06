using System;

namespace Shops.Tools
{
    public class NotEnoughProductCountShopException : ShopException
    {
        public NotEnoughProductCountShopException()
        {
        }

        public NotEnoughProductCountShopException(string message)
            : base(message)
        {
        }

        public NotEnoughProductCountShopException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
