using System;
using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Services
{
    public class CentralBank : ICentralBank
    {
        private List<Bank> _banks = new List<Bank>();
        private List<AccountTransaction> _transactions = new List<AccountTransaction>();

        private delegate void CapEvent(DateTime target);

        private event CapEvent Capital;

        public Bank RegBank(string name)
        {
            if (FindBank(name) == null)
            {
                var bank = new Bank(this, name);
                _banks.Add(bank);
                Capital += bank.Capitalize;
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
            Capital?.Invoke(target);
        }

        public void TransactionMoney(IAccount outAc, IAccount toAc, long money)
        {
            outAc.Transaction(money, toAc);
            MakeHistory(outAc, toAc, money, new TransferType());
        }

        public void MakeHistory(IAccount outAc, IAccount toAc, long money, ITransaction transaction)
        {
            _transactions.Add(new AccountTransaction(transaction, outAc, toAc, money));
        }

        public void CancelLastTransaction(IAccount account)
        {
            for (int i = _transactions.Count - 1; i != -1; --i)
            {
                if (_transactions[i].OutAccount == account || _transactions[i].ToAccount == account)
                {
                    _transactions[i].Transaction.CancelTransaction(_transactions[i].OutAccount, _transactions[i].ToAccount, _transactions[i].Money);

                    _transactions.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
