using System;
using System.Collections.Generic;
using Shops.Tools;

namespace Shops.Services
{
    public class Shop
    {
        private IReadOnlyDictionary<uint, Product> _regProducts;

        private Dictionary<uint, ProductInShop> _products = new Dictionary<uint, ProductInShop>();

        public Shop(string name, string address, IReadOnlyDictionary<uint, Product> regProducts)
        {
            Name = name;
            Address = address;
            _regProducts = regProducts;
        }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public IReadOnlyDictionary<uint, ProductInShop> Products { get => _products; }

        public void RequestForProducts(uint idProduct, uint count)
        {
            if (!_regProducts.ContainsKey(idProduct))
                throw new ProductNotFoundShopException("Product isn`t in the database");

            if (!_products.ContainsKey(idProduct))
            {
                _products.Add(idProduct, new ProductInShop(_regProducts[idProduct], count, 0));
                SetPrice(idProduct, (uint)new Random().Next(1, 100));
            }
            else
            {
                _products[idProduct].ChangeCount((int)count);
            }
        }

        public void SellProduct(uint idProduct, uint count, Customer customer)
        {
            SellManyProducts(new[] { (idProduct, count) }, customer);
        }

        public void SellManyProducts((uint, uint)[] productIdCount, Customer customer)
        {
            uint price = 0;
            for (int i = 0; i != productIdCount.Length; ++i)
            {
                if (!_products.ContainsKey(productIdCount[i].Item1))
                    throw new ProductNotFoundShopException("Product isn`t in the shop`s database");
                if (_products[productIdCount[i].Item1].Count < productIdCount[i].Item2)
                    throw new NotEnoughProductCountShopException("There are not so many products in the shop");

                price += _products[productIdCount[i].Item1].Price * productIdCount[i].Item2;
            }

            if (!customer.IsEnoughMoney(price))
                throw new NotEnoughMoneyShopException("Customer haven`t money");

            customer.SpendMoney((int)price);
            for (int i = 0; i != productIdCount.Length; ++i)
                _products[productIdCount[i].Item1].ChangeCount(-(int)productIdCount[i].Item2);
        }

        public void SetPrice(uint idProduct, uint newPrice)
        {
            if (!_products.ContainsKey(idProduct))
                throw new ProductNotFoundShopException("Product isn`t in the shop`s database");

            _products[idProduct].ChangePrice(newPrice);
        }

        public uint? FindProductPrice(uint idProduct)
        {
            if (!_products.ContainsKey(idProduct))
                return null;

            return _products[idProduct].Price;
        }

        public uint? FindProductCount(uint idProduct)
        {
            if (!_products.ContainsKey(idProduct))
                return null;

            return _products[idProduct].Count;
        }
    }
}
