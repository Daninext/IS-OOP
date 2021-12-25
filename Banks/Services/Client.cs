using System;
using System.Globalization;
using Banks.Tools;

namespace Banks.Services
{
    public class Client
    {
        public Client(RegFormBuilder form, Bank bank)
        {
            FormBuilder = form;
            MBank = bank;
        }

        public RegFormBuilder FormBuilder { get; private set; }

        public Debit DebitAc { get; private set; } = null;
        public Credit CreditAc { get; private set; } = null;
        public Deposit DepositAc { get; private set; } = null;

        public Bank MBank { get; }

        public long TempDebitMoney { get; set; }
        public long TempDepositMoney { get; set; }
        public long TempCreditMoney { get; set; }

        public void CreateDebitAc(float percentages, long startMoney = 0)
        {
            if (DebitAc != null)
                throw new AccountExistsBanksException("Client already has debit account");

            DebitAc = new Debit(this, percentages, startMoney);
        }

        public void CreateCreditAc(float fee, long startMoney = 0)
        {
            if (CreditAc != null)
                throw new AccountExistsBanksException("Client already has credit account");

            CreditAc = new Credit(this, fee, startMoney);
        }

        public void CreateDepositAc(DateTime endAcTime, DinPercentages percentages = null, long startMoney = 0)
        {
            if (DepositAc != null)
                throw new AccountExistsBanksException("Client already has deposit account");

            DepositAc = new Deposit(this, endAcTime, percentages, startMoney);
        }

        public void ChangeDebitPers(float newPers)
        {
            if (DebitAc != null)
                DebitAc.ChangePercentages(newPers);

            // Notification about new pers
        }

        public void ChangeCreditFee(float newFee)
        {
            if (CreditAc != null)
                CreditAc.ChangeFee(newFee);

            // Notification about new fee
        }

        public long ExtraDebitMoney()
        {
            if (DebitAc == null)
                throw new AccountNotExistsBanksException("Client hasn`t debit account");

            return (long)(DebitAc.Money * (DebitAc.Percentages / (new GregorianCalendar().GetDaysInYear(DateTime.Now.Year) * 100)));
        }

        public long ExtraDepositMoney()
        {
            if (DepositAc == null)
                throw new AccountNotExistsBanksException("Client hasn`t credit account");

            return (long)(DepositAc.Money * (DepositAc.Percentages.GetPercent(DepositAc.Money) / (new GregorianCalendar().GetDaysInYear(DateTime.Now.Year) * 100)));
        }

        public long ExtraCreditMoney()
        {
            if (CreditAc == null)
                throw new AccountNotExistsBanksException("Client hasn`t deposit account");

            if (CreditAc.Money > 0)
                return 0;

            return (long)(CreditAc.Money * (CreditAc.Fee / (new GregorianCalendar().GetDaysInYear(DateTime.Now.Year) * 100)));
        }
    }
}
