using System;
using System.Globalization;
using Banks.Tools;

namespace Banks.Services
{
    public class Debit : IAccount
    {
        private Client _handler;
        private RealMoney _money = new RealMoney(0);
        private RealMoney _moneyForPercentes = new RealMoney(0);

        public Debit(Client handler, float percentages, float startMoney = 0f)
        {
            _handler = handler;
            _money.AddMoney(startMoney);
            Percentages = percentages;
        }

        public RealMoney Money => _money;

        public float Percentages { get; private set; }

        public void ChangePercentages(float newPercentages)
        {
            Percentages = newPercentages;
        }

        public void DepositMoney(float money)
        {
            if (money < 0)
                throw new InvalidMoneyCountBanksException("Invalid money count");

            _money.AddMoney(money);
        }

        public void WithdrawMoney(float money)
        {
            if (money < 0 || money > _money.Show())
                throw new InvalidMoneyCountBanksException("Invalid money count");
            if (!_handler.FormBuilder.Form.IsConfirmed() && money > _handler.MainBank.WithdrawLimit)
                throw new OutOfLimitBanksException("Out of withdraw limit");

            _money.AddMoney(-money);
        }

        public void Transfer(float money, IAccount account)
        {
            if (!_handler.FormBuilder.Form.IsConfirmed() && money > _handler.MainBank.TransferLimit)
                throw new OutOfLimitBanksException("Out of transfer limit");

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
            _moneyForPercentes.AddMoney(_money.Show() * (Percentages / (new GregorianCalendar().GetDaysInYear(DateTime.Now.Year) * 100)));
        }

        public float ShowMoney()
        {
            return _money.Show();
        }
    }
}
