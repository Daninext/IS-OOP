using System;

namespace Shops.Tools
{
    public class ProductNotFoundShopException : ShopException
    {
        public ProductNotFoundShopException()
        {
        }

        public ProductNotFoundShopException(string message)
            : base(message)
        {
        }

        public ProductNotFoundShopException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
