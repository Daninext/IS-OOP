using System;
using System.Globalization;
using Banks.Tools;

namespace Banks.Services
{
    public class Credit : IAccount
    {
        private Client _handler;
        private RealMoney _money = new RealMoney(0);
        private RealMoney _moneyForPercentes = new RealMoney(0);

        public Credit(Client handler, float fee, long startMoney = 0)
        {
            _handler = handler;
            Fee = fee;
            _money.AddMoney(startMoney);
        }

        public RealMoney Money => _money;

        public float Fee { get; private set; }

        public void ChangeFee(float newFee)
        {
            Fee = newFee;
        }

        public void DepositMoney(float money)
        {
            if (money < 0)
                throw new InvalidMoneyCountBanksException("Invalid money count");

            _money.AddMoney(money);
        }

        public void WithdrawMoney(float money)
        {
            if (money < 0)
                throw new InvalidMoneyCountBanksException("Invalid money count");

            _money.AddMoney(-money);
        }

        public void Transfer(float money, IAccount account)
        {
            WithdrawMoney(money);
            account.DepositMoney(money);
        }

        public void Capitalize()
        {
            _money.AddMoney(_moneyForPercentes);
            _moneyForPercentes = new RealMoney(0);
        }

        public void CalculateExtraMoney()
        {
            if (_money.Show() > 0)
                return;

            _moneyForPercentes.AddMoney(_money.Show() * (Fee / (new GregorianCalendar().GetDaysInYear(DateTime.Now.Year) * 100)));
        }

        public float ShowMoney()
        {
            return _money.Show();
        }
    }
}
