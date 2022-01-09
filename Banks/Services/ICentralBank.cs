using System;

namespace Banks.Services
{
    public interface ICentralBank
    {
        Bank RegBank(string name, DynamicPercentages depositPercentages, float debitPers = 1f, float creditFee = 1f);
        Bank FindBank(string name);
        void CapTime(DateTime target);
        void TransactionMoney(IAccount outAccount, IAccount toAccount, float money);
        void MakeHistory(IAccount outAccount, IAccount toAccount, float money, ITransaction transaction);
        void CancelLastTransaction(IAccount account);
    }
}
