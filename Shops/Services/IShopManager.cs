namespace Shops.Services
{
    public interface IShopManager
    {
        public int RegShop(string name, string address);

        public Shop FindShop(int id);

        public int RegProduct(string name);

        public Product GetProduct(int id);

        public void GlobalRequestForProducts(Shop shop, int idProduct, int count, int price = 0);

        public Shop FindCheapShop(RequestableProduct[] reqProducts);
    }
}
