using System;
using Shops.Tools;

namespace Shops.Services
{
    public class ProductInShop
    {
        public ProductInShop(Product product, int count, int price)
        {
            ShopProduct = product;
            ChangeCount(count);
            ChangePrice(price);
        }

        public Product ShopProduct { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }

        public void ChangeCount(int delta)
        {
            if (delta < 0 && Count < Math.Abs(delta))
                throw new NotEnoughProductCountShopException("There are not so many products in the shop");

            Count += delta;
        }

        public void ChangePrice(int newPrice)
        {
            if (newPrice < 0)
                throw new InvalidPriceShopException("There is a invalid price");

            Price = newPrice;
        }
    }
}
