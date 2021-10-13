using System.Collections.Generic;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopManager : IShopManager
    {
        private int _nextIdShop = 1;
        private int _nextIdProduct = 1;

        private Dictionary<int, Shop> _shops = new Dictionary<int, Shop>();
        private Dictionary<int, Product> _products = new Dictionary<int, Product>();

        public IReadOnlyDictionary<int, Shop> Shops { get => _shops; }

        public IReadOnlyDictionary<int, Product> Products { get => _products; }

        public int RegShop(string name, string address)
        {
            var newShop = new Shop(name, address);
            _shops.Add(_nextIdShop, newShop);
            _nextIdShop++;
            return _nextIdShop - 1;
        }

        public Shop FindShop(int id)
        {
            if (!_shops.ContainsKey(id))
                return null;

            return _shops[id];
        }

        public int RegProduct(string name)
        {
            var newProduct = new Product(name);
            _products.Add(_nextIdProduct, newProduct);
            _nextIdProduct++;
            return _nextIdProduct - 1;
        }

        public Product GetProduct(int id)
        {
            if (!_products.ContainsKey(id))
                throw new ProductNotFoundShopException("Product isn`t in the database");

            return _products[id];
        }

        public void GlobalRequestForProducts(Shop shop, int idProduct, int count, int price = 0)
        {
            if (idProduct < 0)
                throw new InvalidIdShopException("There is a invalid ID");
            if (count < 0)
                throw new InvalidCountShopException("There is a invalid count");
            if (price < 0)
                throw new InvalidPriceShopException("There is a invalid price");

            shop.RequestForProducts(GetProduct(idProduct), idProduct, count, price);
        }

        public Shop FindCheapShop(RequestableProduct[] reqProducts)
        {
            for (int i = 0; i != reqProducts.Length; ++i)
                GetProduct(reqProducts[i].ID);

            int? minPrice = null;
            Shop cheapShop = null;
            foreach (KeyValuePair<int, Shop> idShop in _shops)
            {
                bool isProductInShop = true;
                for (int i = 0; i != reqProducts.Length; ++i)
                {
                    if (idShop.Value.FindProductCount(reqProducts[i].ID) == null || idShop.Value.FindProductCount(reqProducts[i].ID) < reqProducts[i].Count)
                    {
                        isProductInShop = false;
                        break;
                    }
                }

                if (!isProductInShop)
                    continue;

                int curPrice = 0;
                for (int i = 0; i != reqProducts.Length; ++i)
                {
                    curPrice += (int)idShop.Value.FindProductPrice(reqProducts[i].ID) * reqProducts[i].Count;
                }

                if (minPrice == null || minPrice > curPrice)
                {
                    minPrice = curPrice;
                    cheapShop = idShop.Value;
                }
            }

            return cheapShop;
        }
    }
}