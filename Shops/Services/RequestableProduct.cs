using Shops.Tools;

namespace Shops.Services
{
    public class RequestableProduct
    {
        private int _id;
        private int _count;

        public RequestableProduct(int id, int count)
        {
            ID = id;
            Count = count;
        }

        public int ID { get => _id; set { if (value < 0) throw new InvalidPriceShopException("There is a invalid ID"); else _id = value; } }
        public int Count { get => _count; set { if (value < 0) throw new InvalidCountShopException("There is a invalid count"); else _count = value; } }
    }
}
