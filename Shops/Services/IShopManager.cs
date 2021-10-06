namespace Shops.Services
{
    public interface IShopManager
    {
        public uint RegShop(string name, string address);

        public Shop FindShop(uint id);

        public uint RegProduct(string name);

        public Product GetProduct(uint id);

        public Shop FindCheapShop((uint, uint)[] productIdCount);
    }
}
