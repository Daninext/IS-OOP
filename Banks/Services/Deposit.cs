using System;
using Banks.Tools;

namespace Banks.Services
{
    public class Deposit : IAccount
    {
        private Client _handler;
        private long _money = 0;
        private DateTime _endDate;

        public Deposit(Client handler, DateTime endAcTime, DinPercentages percentages = null, long startMoney = 0)
        {
            _handler = handler;
            _money = startMoney;
            _endDate = endAcTime;

            if (percentages == null)
                Percentages = new DinPercentages();
            else
                Percentages = percentages;
        }

        public DinPercentages Percentages { get; private set; }

        public long Money
        {
            get => _money;
            private set
            {
                if (value < _money)
                    throw new WithdrawDenyBanksException("You can`t withdraw money");

                _money = value;
            }
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
