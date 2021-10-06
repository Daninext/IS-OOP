using System.Collections.Generic;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopManager : IShopManager
    {
        private uint _nextIdShop = 1;
        private uint _nextIdProduct = 1;

        private Dictionary<uint, Shop> _shops = new Dictionary<uint, Shop>();
        private Dictionary<uint, Product> _products = new Dictionary<uint, Product>();

        public IReadOnlyDictionary<uint, Shop> Shops { get => _shops; }

        public IReadOnlyDictionary<uint, Product> Products { get => _products; }

        public uint RegShop(string name, string address)
        {
            var newShop = new Shop(name, address, this);
            _shops.Add(_nextIdShop, newShop);
            _nextIdShop++;
            return _nextIdShop - 1;
        }

        public Shop FindShop(uint id)
        {
            if (!_shops.ContainsKey(id))
                return null;

            return _shops[id];
        }

        public uint RegProduct(string name)
        {
            var newProduct = new Product(name);
            _products.Add(_nextIdProduct, newProduct);
            _nextIdProduct++;
            return _nextIdProduct - 1;
        }

        public Product GetProduct(uint id)
        {
            if (!_products.ContainsKey(id))
                throw new ProductNotFoundShopException("Product isn`t in the database");

            return _products[id];
        }

        public Shop FindCheapShop((uint, uint)[] productIdCount)
        {
            for (int i = 0; i != productIdCount.Length; ++i)
                GetProduct(productIdCount[i].Item1);

            int? minPrice = null;
            Shop cheapShop = null;
            foreach (KeyValuePair<uint, Shop> idShop in _shops)
            {
                bool flag = false;
                for (int i = 0; i != productIdCount.Length; ++i)
                {
                    if (idShop.Value.FindProductCount(productIdCount[i].Item1) == null || idShop.Value.FindProductCount(productIdCount[i].Item1) < productIdCount[i].Item2)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                    continue;

                int curPrice = 0;
                for (int i = 0; i != productIdCount.Length; ++i)
                {
                    curPrice += (int)idShop.Value.FindProductPrice(productIdCount[i].Item1) * (int)productIdCount[i].Item2;
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