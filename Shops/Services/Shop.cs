using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Shops.Tools;

[assembly: InternalsVisibleTo("ShopManager")]
namespace Shops.Services
{
    public class Shop
    {
        private Dictionary<int, ProductInShop> _products = new Dictionary<int, ProductInShop>();

        public Shop(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public IReadOnlyDictionary<int, ProductInShop> Products { get => _products; }

        public void SellProduct(int idProduct, int count, Customer customer)
        {
            SellManyProducts(new[] { new RequestableProduct(idProduct, count) }, customer);
        }

        public void SellManyProducts(RequestableProduct[] reqProducts, Customer customer)
        {
            int price = 0;
            for (int i = 0; i != reqProducts.Length; ++i)
            {
                if (reqProducts[i].ID < 0)
                    throw new InvalidIdShopException("There is a invalid ID");
                if (reqProducts[i].Count < 0)
                    throw new InvalidCountShopException("There is a invalid count");
                if (!_products.ContainsKey(reqProducts[i].ID))
                    throw new ProductNotFoundShopException("Product isn`t in the shop`s database");
                if (_products[reqProducts[i].ID].Count < reqProducts[i].Count)
                    throw new NotEnoughProductCountShopException("There are not so many products in the shop");

                price += _products[reqProducts[i].ID].Price * reqProducts[i].Count;
            }

            customer.SpendMoney(price);
            for (int i = 0; i != reqProducts.Length; ++i)
                _products[reqProducts[i].ID].ChangeCount(-reqProducts[i].Count);
        }

        public void SetPrice(int idProduct, int newPrice)
        {
            if (!_products.ContainsKey(idProduct))
                throw new ProductNotFoundShopException("Product isn`t in the shop`s database");

            _products[idProduct].ChangePrice(newPrice);
        }

        public int? FindProductPrice(int idProduct)
        {
            if (!_products.ContainsKey(idProduct))
                return null;

            return _products[idProduct].Price;
        }

        public int? FindProductCount(int idProduct)
        {
            if (!_products.ContainsKey(idProduct))
                return null;

            return _products[idProduct].Count;
        }

        internal void RequestForProducts(Product product, int idProduct, int count, int price)
        {
            if (!_products.ContainsKey(idProduct))
            {
                _products.Add(idProduct, new ProductInShop(product, count, price));
            }
            else
            {
                _products[idProduct].ChangeCount(count);
            }
        }
    }
}
