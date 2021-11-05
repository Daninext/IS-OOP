using Shops.Tools;

namespace Shops.Services
{
    public class Customer
    {
        private int _money;

        public Customer(string name, int money)
        {
            Name = name;
            _money = money;
        }

        public string Name { get; private set; }

        public int Money { get => _money; }

        public bool IsEnoughMoney(int needMoney)
        {
            return needMoney <= _money;
        }

        public void SpendMoney(int needMoney)
        {
            if (!IsEnoughMoney(needMoney))
                throw new NotEnoughMoneyShopException("Customer haven`t money");

            _money -= needMoney;
        }
    }
}
