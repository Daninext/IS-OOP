using System;
using System.Globalization;
using Banks.Tools;

namespace Banks.Services
{
    public class Deposit : IAccount
    {
        private Client _handler;
        private DateTime _endDate;
        private RealMoney _money = new RealMoney(0);
        private RealMoney _moneyForPercentes = new RealMoney(0);

        public Deposit(Client handler, DateTime endAcTime, DinPercentages percentages = null, long startMoney = 0)
        {
            _handler = handler;
            _money.AddMoney(startMoney);
            _endDate = endAcTime;

            if (percentages == null)
                Percentages = new DinPercentages();
            else
                Percentages = percentages;
        }

        public RealMoney Money => _money;

        public DinPercentages Percentages { get; private set; }

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
            if (DateTime.Now < _endDate)
                throw new WithdrawDenyBanksException("The end date has not yet arrived");

            _money.AddMoney(-money);
        }

        public void Transfer(float money, IAccount account)
        {
            if (DateTime.Now < _endDate)
                throw new WithdrawDenyBanksException("The end date has not yet arrived");

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
            _moneyForPercentes.AddMoney(_money.Show() * (Percentages.GetPercent(_money.Show()) / (new GregorianCalendar().GetDaysInYear(DateTime.Now.Year) * 100)));
        }

        public float ShowMoney()
        {
            return _money.Show();
        }
    }
}
