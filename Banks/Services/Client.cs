using System;
using System.Collections.Generic;

namespace Banks.Services
{
    public class Client
    {
        private List<IAccount> _accounts = new List<IAccount>();
        private INotification notification = new NotifyByEMail();

        public Client(RegFormBuilder form, Bank bank)
        {
            FormBuilder = form;
            MainBank = bank;
        }

        public RegFormBuilder FormBuilder { get; private set; }

        public IReadOnlyList<IAccount> Accounts => _accounts;

        public Bank MainBank { get; }

        public void CreateDebitAc(float percentages, long startMoney = 0)
        {
            _accounts.Add(new Debit(this, percentages, startMoney));
        }

        public void CreateCreditAc(float fee, long startMoney = 0)
        {
            _accounts.Add(new Credit(this, fee, startMoney));
        }

        public void CreateDepositAc(DateTime endAcTime, DynamicPercentages percentages, long startMoney = 0)
        {
            _accounts.Add(new Deposit(this, endAcTime, percentages, startMoney));
        }

        public void ChangeDebitPers(float newPercentages)
        {
            foreach (Debit account in _accounts)
            {
                account.ChangePercentages(newPercentages);
            }

            notification.Notify(this, "This is a percentages change notification", "We have changed percentages on your debit accounts. Now it is " + newPercentages.ToString());
        }

        public void ChangeCreditFee(float newFee)
        {
            foreach (Credit account in _accounts)
            {
                account.ChangeFee(newFee);
            }

            notification.Notify(this, "This is a percentages change notification", "We have changed fee on your credit accounts. Now it is " + newFee.ToString());
        }

        public void ChangeNotifyType(INotification newNotification)
        {
            notification = newNotification;
        }
    }
}
