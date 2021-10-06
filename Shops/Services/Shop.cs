using System;
using System.Collections.Generic;
using Shops.Tools;

namespace Shops.Services
{
    public class Shop
    {
        private ShopManager _shopManager;

        private Dictionary<uint, (Product, uint, uint)> _products = new Dictionary<uint, (Product, uint, uint)>(); // Product, count, price

        public Shop(string name, string address, ShopManager shopManager)
        {
            Name = name;
            Address = address;
            _shopManager = shopManager;
        }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public IReadOnlyDictionary<uint, (Product, uint, uint)> Products { get => _products; }

        public void GetDelivery(uint idProduct, uint count)
        {
            Product product = _shopManager.GetProduct(idProduct);

            if (!_products.ContainsKey(idProduct))
            {
                _products.Add(idProduct, (product, count, 0));
                SetPrice(idProduct, (uint)new Random().Next(1, 100));
            }
            else
            {
                _products[idProduct] = (_products[idProduct].Item1, _products[idProduct].Item2 + count, _products[idProduct].Item3);
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
                if (_products[productIdCount[i].Item1].Item2 < productIdCount[i].Item2)
                    throw new NotEnoughProductCountShopException("There are not so many products in the shop");

                price += _products[productIdCount[i].Item1].Item3 * productIdCount[i].Item2;
            }

            if (!customer.IsEnoughMoney(price))
                throw new NotEnoughMoneyShopException("Customer haven`t money");

            customer.SpendMoney((int)price);
            for (int i = 0; i != productIdCount.Length; ++i)
                _products[productIdCount[i].Item1] = (_products[productIdCount[i].Item1].Item1, _products[productIdCount[i].Item1].Item2 - productIdCount[i].Item2, _products[productIdCount[i].Item1].Item3);
        }

        public void SetPrice(uint idProduct, uint newPrice)
        {
            if (!_products.ContainsKey(idProduct))
                throw new ProductNotFoundShopException("Product isn`t in the shop`s database");

            _products[idProduct] = (_products[idProduct].Item1, _products[idProduct].Item2, newPrice);
        }

        public uint? FindProductPrice(uint idProduct)
        {
            if (!_products.ContainsKey(idProduct))
                return null;

            return _products[idProduct].Item3;
        }

        public uint? FindProductCount(uint idProduct)
        {
            if (!_products.ContainsKey(idProduct))
                return null;

            return _products[idProduct].Item2;
        }
    }
}
