namespace Shops.Services
{
    public class Product
    {
        public Product(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
