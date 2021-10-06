using Shops.Tools;

namespace Shops.Services
{
    public class Customer
    {
        private string _name;
        private int _money;

        public Customer(string name, int money)
        {
            _name = name;
            _money = money;
        }

        public string Name { get => _name; }

        public int Money { get => _money; }

        public bool IsEnoughMoney(uint needMoney)
        {
            return needMoney <= _money;
        }

        public void SpendMoney(int needMoney)
        {
            if (!IsEnoughMoney((uint)needMoney))
                throw new NotEnoughMoneyShopException("Customer haven`t money");

            _money -= needMoney;
        }
    }
}
