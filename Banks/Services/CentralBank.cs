using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Services
{
    public class CentralBank : ICentralBank
    {
        private List<Bank> _banks = new List<Bank>();
        private List<AccountTransaction> _transactions = new List<AccountTransaction>();

        private delegate void CapEvent(int days);

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

        public void CapTime(int days)
        {
            Capital?.Invoke(days);
        }

        public void TransactionMoney(IAccount outAc, IAccount toAc, long money)
        {
            outAc.Transaction(money, toAc);
            MakeHistory(outAc, toAc, money, "transfer");
        }

        public void MakeHistory(IAccount outAc, IAccount toAc, long money, string type)
        {
            _transactions.Add(new AccountTransaction(type, outAc, toAc, money));
        }

        public void CancelLastTransaction(IAccount account)
        {
            for (int i = _transactions.Count - 1; i != -1; --i)
            {
                if (_transactions[i].OutAccount == account || _transactions[i].ToAccount == account)
                {
                    switch (_transactions[i].TransactionType)
                    {
                        case "transfer":
                            if (_transactions[i].OutAccount == account)
                            {
                                account.DepositMoney(_transactions[i].Money);
                                _transactions[i].ToAccount.WithdrawMoney(_transactions[i].Money);
                            }
                            else
                            {
                                account.WithdrawMoney(_transactions[i].Money);
                                _transactions[i].ToAccount.DepositMoney(_transactions[i].Money);
                            }

                            break;

                        case "withdraw":
                            account.DepositMoney(_transactions[i].Money);
                            break;

                        case "deposit":
                            account.WithdrawMoney(_transactions[i].Money);
                            break;
                    }

                    _transactions.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
