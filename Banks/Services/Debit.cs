using Banks.Tools;

namespace Banks.Services
{
    public class Debit : IAccount
    {
        private Client _handler;
        private long _money;

        public Debit(Client handler, float percentages, long startMoney = 0)
        {
            _handler = handler;
            _money = startMoney;
            Percentages = percentages;
        }

        public long Money
        {
            get => _money;
            private set
            {
                if (value < 0)
                    throw new InvalidMoneyCountBanksException("Not enought money");

                _money = value;
            }
        }

        public float Percentages { get; private set; }

        public void ChangePercentages(float newPercentages)
        {
            Percentages = newPercentages;
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
            if (!_handler.FormBuilder.Form.IsConfirmed() && money > _handler.MBank.WithdrawLimit)
                throw new OutOfLimitBanksException("Out of withdraw limit");

            Money -= money;
        }

        public void Transaction(long money, IAccount account)
        {
            if (!_handler.FormBuilder.Form.IsConfirmed() && money > _handler.MBank.TransferLimit)
                throw new OutOfLimitBanksException("Out of transfer limit");

            WithdrawMoney(money);
            account.DepositMoney(money);
        }
    }
}
