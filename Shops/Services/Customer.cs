using Shops.Tools;

namespace Shops.Services
{
    public class Customer
    {
        public Customer(string name, int money)
        {
            Name = name;
            Money = money;
        }

        public string Name { get; private set; }

        public int Money { get; private set; }

        public bool IsEnoughMoney(int needMoney)
        {
            return needMoney <= Money;
        }

        public void SpendMoney(int needMoney)
        {
            if (!IsEnoughMoney(needMoney))
                throw new NotEnoughMoneyShopException("Customer haven`t money");

            Money -= needMoney;
        }
    }
}
