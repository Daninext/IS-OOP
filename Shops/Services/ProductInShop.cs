using System;
using Shops.Tools;

namespace Shops.Services
{
    public class ProductInShop
    {
        public ProductInShop(Product product, uint count, uint price)
        {
            ShopProduct = product;
            Count = count;
            Price = price;
        }

        public Product ShopProduct { get; private set; }
        public uint Count { get; private set; }
        public uint Price { get; private set; }

        public void ChangeCount(int delta)
        {
            if (delta < 0 && Count < Math.Abs(delta))
                throw new NotEnoughProductCountShopException("There are not so many products in the shop");

            Count = (uint)(Count + delta);
        }

        public void ChangePrice(uint newPrice)
        {
            Price = newPrice;
        }
    }
}
