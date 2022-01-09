using System;
using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Services
{
    public class CentralBank : ICentralBank
    {
        private List<Bank> _banks = new List<Bank>();
        private List<AccountTransaction> _transactions = new List<AccountTransaction>();

        private delegate void CapitalizeEvent(DateTime target);

        private event CapitalizeEvent Capitalize;

        public Bank RegBank(string name, DynamicPercentages depositPercentages, float debitPers = 1f, float creditFee = 1f)
        {
            if (FindBank(name) == null)
            {
                var bank = new Bank(this, name, depositPercentages, debitPers, creditFee);
                _banks.Add(bank);
                Capitalize += bank.Capitalize;
                return bank;
            }

            throw new SameBankBanksException("There is same Bank");
        }

        public Bank FindBank(string name)
        {
            foreach (Bank bank in _banks)
            {
                if (bank.Name == name)
                    return bank;
            }

            return null;
        }

        public void CapTime(DateTime target)
        {
            Capitalize?.Invoke(target);
        }

        public void TransactionMoney(IAccount outAccount, IAccount toAccount, float money)
        {
            outAccount.Transfer(money, toAccount);
            MakeHistory(outAccount, toAccount, money, new TransferType());
        }

        public void MakeHistory(IAccount outAccount, IAccount toAccount, float money, ITransaction transaction)
        {
            _transactions.Add(new AccountTransaction(transaction, outAccount, toAccount, money));
        }

        public void CancelLastTransaction(IAccount account)
        {
            for (int i = _transactions.Count - 1; i != -1; --i)
            {
                if (_transactions[i].OutAccount == account || _transactions[i].ToAccount == account)
                {
                    _transactions[i].Transaction.CancelTransaction(_transactions[i]);

                    _transactions.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
