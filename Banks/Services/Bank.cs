using System;
using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Services
{
    public class Bank
    {
        private CentralBank _centralBank;

        private float _debitPercentages;
        private float _creditFee;
        private DateTime _date = DateTime.Now;
        private DinPercentages _depositPercentages;

        private List<Client> _clients = new List<Client>();

        public Bank(CentralBank cenBank, string name, float debPers = 1f, float crFee = 1f, DinPercentages depPercentages = null)
        {
            _centralBank = cenBank;

            Name = name;
            _debitPercentages = debPers;
            _creditFee = crFee;

            if (depPercentages == null)
                _depositPercentages = new DinPercentages();
            else
                _depositPercentages = depPercentages;
        }

        private delegate void DebitPersChanger(float newPers);
        private delegate void CreditFeeChanger(float newFee);

        private event DebitPersChanger DebChanger;
        private event CreditFeeChanger CreditChanger;

        public string Name { get; private set; }

        public float DebitPercentages
        {
            get => _debitPercentages;
            private set
            {
                if (value < 0)
                    throw new Exception("Negative pers");

                _debitPercentages = value;
            }
        }

        public float CreditFee
        {
            get => _creditFee;
            private set
            {
                if (value < 0)
                    throw new Exception("Negative fee");

                _creditFee = value;
            }
        }

        public DinPercentages DepositPercentages
        {
            get => _depositPercentages;
            private set
            {
                if (value == null)
                    throw new Exception("Deposit plan is null");

                _depositPercentages = value;
            }
        }

        public long WithdrawLimit { get; private set; } = 8000;
        public long TransferLimit { get; private set; } = 5000;

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

        public void ChangeDebitPers(float newPers)
        {
            _debitPercentages = newPers;
            DebChanger?.Invoke(_debitPercentages);
        }

        public void ChangeCreditFee(float newFee)
        {
            _creditFee = newFee;
            CreditChanger?.Invoke(_creditFee);
        }

        public void CreateDebitAc(Client client, long startMoney = 0)
        {
            client.CreateDebitAc(_debitPercentages, startMoney);
            DebChanger += client.ChangeDebitPers;
        }

        public void CreateCreditAc(Client client, long startMoney = 0)
        {
            client.CreateCreditAc(_creditFee, startMoney);
            CreditChanger += client.ChangeCreditFee;
        }

        public void CreateDepositAc(Client client, DateTime endAcTime, long startMoney = 0)
        {
            client.CreateDepositAc(endAcTime, _depositPercentages, startMoney);
        }

        public void Capitalize(DateTime targetDate)
        {
            while (_date.Date != targetDate.Date)
            {
                _date = _date.AddDays(1);

                if (_date.Day == 1)
                {
                    foreach (Client client in _clients)
                    {
                        if (client.DebitAc != null)
                            client.TempDebitMoney += client.ExtraDebitMoney();
                        if (client.CreditAc != null)
                            client.TempCreditMoney += client.ExtraCreditMoney();
                        if (client.DepositAc != null)
                            client.TempDepositMoney += client.ExtraDepositMoney();
                    }
                }
                else
                {
                    foreach (Client client in _clients)
                    {
                        if (client.DebitAc != null)
                        {
                            client.TempDebitMoney += client.ExtraDebitMoney();
                            client.DebitAc.DepositMoney(client.TempDebitMoney);
                            client.TempDebitMoney = 0;
                        }

                        if (client.CreditAc != null)
                        {
                            client.TempCreditMoney += client.ExtraCreditMoney();
                            client.CreditAc.DepositMoney(client.TempCreditMoney);
                            client.TempCreditMoney = 0;
                        }

                        if (client.DepositAc != null)
                        {
                            client.TempDepositMoney += client.ExtraDepositMoney();
                            client.DebitAc.DepositMoney(client.TempDepositMoney);
                            client.TempDepositMoney = 0;
                        }
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