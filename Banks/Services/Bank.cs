using System;
using System.Collections.Generic;
using System.Net.Mail;
using Banks.Tools;

namespace Banks.Services
{
    public class Bank
    {
        private CentralBank _centralBank;

        private float _debitPercentages;
        private float _creditFee;
        private DateTime _date = new DateTime(2021, 1, 1);
        private DynamicPercentages _depositPercentages;

        private List<Client> _clients = new List<Client>();

        public Bank(CentralBank centralBank, string name, DynamicPercentages depositPercentages, float debitPers, float creditFee)
        {
            _centralBank = centralBank;

            Name = name;
            _debitPercentages = debitPers;
            _creditFee = creditFee;
            _depositPercentages = depositPercentages;

            BankEmail = new MailAddress("ourbank@bank.com");
        }

        private delegate void DebitPersChanger(float newPers);
        private delegate void CreditFeeChanger(float newFee);

        private event DebitPersChanger DebitChanger;
        private event CreditFeeChanger CreditChanger;

        public string Name { get; private set; }

        public float DebitPercentages
        {
            get => _debitPercentages;
            private set
            {
                if (value < 0)
                    throw new InvalidPercentagesBanksException("Negative percentages");

                _debitPercentages = value;
            }
        }

        public float CreditFee
        {
            get => _creditFee;
            private set
            {
                if (value < 0)
                    throw new InvalidPercentagesBanksException("Negative fee");

                _creditFee = value;
            }
        }

        public DynamicPercentages DepositPercentages
        {
            get => _depositPercentages;
            private set
            {
                if (value == null)
                    throw new InvalidPercentagesBanksException("Deposit plan is null");

                _depositPercentages = value;
            }
        }

        public long WithdrawLimit { get; private set; } = 8000;
        public long TransferLimit { get; private set; } = 5000;

        public MailAddress BankEmail { get; private set; }

        public string SMTP { get; private set; }

        public void ChangeBankEmail(string email)
        {
            MailAddress newEmail;
            if (!MailAddress.TryCreate(email, out newEmail))
                throw new InvalidRegDataBanksException("Invalid email");

            BankEmail = newEmail;
        }

        public void ChangeSMTP(string newSMTP)
        {
            // Some checking for correctness
            SMTP = newSMTP;
        }

        public Client RegClient(RegFormBuilder form)
        {
            if (FindClient(form.Form.PassportNum) != null)
                throw new SameClientBanksException("There is same client");

            var client = new Client(form, this);
            _clients.Add(client);
            return client;
        }

        public Client FindClient(string passportNum)
        {
            foreach (Client client in _clients)
            {
                if (client.FormBuilder.Form.PassportNum == passportNum)
                    return client;
            }

            return null;
        }

        public void ChangeDebitPers(float newPercentages)
        {
            _debitPercentages = newPercentages;
            DebitChanger?.Invoke(_debitPercentages);
        }

        public void ChangeCreditFee(float newFee)
        {
            _creditFee = newFee;
            CreditChanger?.Invoke(_creditFee);
        }

        public void CreateDebitAc(Client client, long startMoney = 0)
        {
            client.CreateDebitAc(_debitPercentages, startMoney);
            DebitChanger += client.ChangeDebitPers;
        }

        public void CreateCreditAc(Client client, long startMoney = 0)
        {
            client.CreateCreditAc(_creditFee, startMoney);
            CreditChanger += client.ChangeCreditFee;
        }

        public void CreateDepositAc(Client client, DateTime endAccountTime, long startMoney = 0)
        {
            client.CreateDepositAc(endAccountTime, _depositPercentages, startMoney);
        }

        public void Capitalize(DateTime targetDate)
        {
            while (_date.Date != targetDate.Date)
            {
                _date = _date.AddDays(1);

                foreach (Client client in _clients)
                {
                    foreach (IAccount account in client.Accounts)
                    {
                        account.CalculateExtraMoney();

                        if (_date.Day == 1)
                            account.Capitalize();
                    }
                }
            }
        }

        public void Withdraw(IAccount account, long money)
        {
            account.WithdrawMoney(money);
            _centralBank.MakeHistory(account, null, money, new WithdrawType());
        }

        public void Deposit(IAccount account, long money)
        {
            account.DepositMoney(money);
            _centralBank.MakeHistory(account, null, money, new DepositType());
        }

        public void ChangeWithdrawLimit(long newLimit)
        {
            WithdrawLimit = newLimit;
        }

        public void ChangeTransferLimit(long newLimit)
        {
            TransferLimit = newLimit;
        }
    }
}