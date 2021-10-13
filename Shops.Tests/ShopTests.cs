using System.Collections.Generic;
using Shops.Services;
using Shops.Tools;
using NUnit.Framework;

namespace Shops.Tests
{
    public class ShopTests
    {
        private IShopManager _shopManager;

        [SetUp]
        public void Setup()
        {
            _shopManager = null;
        }

        [Test]
        public void RegisterShopsAndProducts_DeliveryThem_CheckForAvailability()
        {
            _shopManager = new ShopManager();
            var shopIds = new List<int>();
            var productIds = new List<int>();

            shopIds.Add(_shopManager.RegShop("First", "street"));
            productIds.Add(_shopManager.RegProduct("Mouse"));

            _shopManager.GlobalRequestForProducts(_shopManager.FindShop(shopIds[0]), productIds[0], 7);

            productIds.Add(_shopManager.RegProduct("Keyboard"));
            _shopManager.GlobalRequestForProducts(_shopManager.FindShop(shopIds[0]), productIds[1], 20);

            shopIds.Add(_shopManager.RegShop("Second", "street"));
            _shopManager.GlobalRequestForProducts(_shopManager.FindShop(shopIds[1]), productIds[1], 35);

            Assert.IsTrue(_shopManager.FindShop(shopIds[0]).FindProductCount(productIds[0]) != null);
            Assert.IsTrue(_shopManager.FindShop(shopIds[0]).FindProductCount(productIds[1]) != null);
            Assert.IsTrue(_shopManager.FindShop(shopIds[1]).FindProductCount(productIds[1]) != null);
        }

        [Test]
        public void SetPrice()
        {
            _shopManager = new ShopManager();
            var shopIds = new List<int>();
            var productIds = new List<int>();

            shopIds.Add(_shopManager.RegShop("First", "street"));
            productIds.Add(_shopManager.RegProduct("Mouse"));

            _shopManager.GlobalRequestForProducts(_shopManager.FindShop(shopIds[0]), productIds[0], 7);
            _shopManager.FindShop(shopIds[0]).SetPrice(productIds[0], 500);

            Assert.AreEqual(_shopManager.FindShop(shopIds[0]).FindProductPrice(productIds[0]), 500);
        }

        [Test]
        public void TryToFindCheapShop()
        {
            _shopManager = new ShopManager();
            var shopIds = new List<int>();
            var productIds = new List<int>();

            shopIds.Add(_shopManager.RegShop("First", "street"));
            productIds.Add(_shopManager.RegProduct("Mouse"));

            _shopManager.GlobalRequestForProducts(_shopManager.FindShop(shopIds[0]), productIds[0], 7);
            _shopManager.FindShop(shopIds[0]).SetPrice(productIds[0], 500);

            productIds.Add(_shopManager.RegProduct("Keyboard"));
            _shopManager.GlobalRequestForProducts(_shopManager.FindShop(shopIds[0]), productIds[1], 20);
            _shopManager.FindShop(shopIds[0]).SetPrice(productIds[1], 800);

            shopIds.Add(_shopManager.RegShop("Second", "street"));
            _shopManager.GlobalRequestForProducts(_shopManager.FindShop(shopIds[1]), productIds[0], 10);
            _shopManager.FindShop(shopIds[1]).SetPrice(productIds[0], 300);
            _shopManager.GlobalRequestForProducts(_shopManager.FindShop(shopIds[1]), productIds[1], 35);
            _shopManager.FindShop(shopIds[1]).SetPrice(productIds[1], 900);

            Assert.AreEqual(_shopManager.FindCheapShop(new[] { new RequestableProduct(productIds[0], 5), new RequestableProduct(productIds[1], 15) }), _shopManager.FindShop(shopIds[0]));
            Assert.AreEqual(_shopManager.FindCheapShop(new[] { new RequestableProduct(productIds[0], 10), new RequestableProduct(productIds[1], 15) }), _shopManager.FindShop(shopIds[1]));
            Assert.AreEqual(_shopManager.FindCheapShop(new[] { new RequestableProduct(productIds[0], 100), new RequestableProduct(productIds[1], 100) }), null);
            Assert.Catch<ShopException>(() =>
            {
                _shopManager.FindCheapShop(new[] { new RequestableProduct(38, 5) });
            });
        }

        [Test]
        public void TryToBuy()
        {
            _shopManager = new ShopManager();
            var customer = new Customer("Artem", 10000);
            var shopIds = new List<int>();
            var productIds = new List<int>();

            shopIds.Add(_shopManager.RegShop("First", "street"));
            productIds.Add(_shopManager.RegProduct("Mouse"));

            _shopManager.GlobalRequestForProducts(_shopManager.FindShop(shopIds[0]), productIds[0], 7);
            _shopManager.FindShop(shopIds[0]).SetPrice(productIds[0], 500);

            productIds.Add(_shopManager.RegProduct("Keyboard"));
            _shopManager.GlobalRequestForProducts(_shopManager.FindShop(shopIds[0]), productIds[1], 20);
            _shopManager.FindShop(shopIds[0]).SetPrice(productIds[1], 800);

            _shopManager.FindShop(shopIds[0]).SellProduct(productIds[0], 1, customer);
            Assert.AreEqual(_shopManager.FindShop(shopIds[0]).FindProductCount(productIds[0]), 6);
            Assert.AreEqual(customer.Money, 9500);

            _shopManager.FindShop(shopIds[0]).SellManyProducts(new[] { new RequestableProduct(productIds[0], 2), new RequestableProduct(productIds[1], 5) }, customer);
            Assert.AreEqual(_shopManager.FindShop(shopIds[0]).FindProductCount(productIds[0]), 4);
            Assert.AreEqual(_shopManager.FindShop(shopIds[0]).FindProductCount(productIds[1]), 15);
            Assert.AreEqual(customer.Money, 4500);

            Assert.Catch<ShopException>(() =>
            {
                _shopManager.FindShop(shopIds[0]).SellProduct(productIds[1], 10, customer);
            });
        }
    }
}
