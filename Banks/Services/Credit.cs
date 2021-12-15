using Banks.Tools;

namespace Banks.Services
{
    public class Credit : IAccount
    {
        private Client _handler;

        public Credit(Client handler, float fee, long startMoney = 0)
        {
            _handler = handler;
            Fee = fee;
            Money = startMoney;
        }

        public long Money { get; private set; }

        public float Fee { get; private set; }

        public void ChangeFee(float newFee)
        {
            Fee = newFee;
        }

        public void DepositMoney(long money)
        {
            if (money < 0)
                throw new InvalidMoneyCountBanksException("Invalid money count");

            Money += money;
        }

        public void WithdrawMoney(long money)
        {
            if (money < 0)
                throw new InvalidMoneyCountBanksException("Invalid money count");

            Money -= money;
        }

        public void Transaction(long money, IAccount account)
        {
            WithdrawMoney(money);
            account.DepositMoney(money);
        }
    }
}
