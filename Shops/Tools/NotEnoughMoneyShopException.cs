using System;

namespace Shops.Tools
{
    public class NotEnoughMoneyShopException : ShopException
    {
        public NotEnoughMoneyShopException()
        {
        }

        public NotEnoughMoneyShopException(string message)
            : base(message)
        {
        }

        public NotEnoughMoneyShopException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
