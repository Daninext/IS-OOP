using System;

namespace Banks.Services
{
    public interface ICentralBank
    {
        Bank RegBank(string name, DinPercentages depPercentages, float debPers = 1f, float credFee = 1f);
        Bank FindBank(string name);
        void CapTime(DateTime target);
        void TransactionMoney(IAccount outAc, IAccount toAc, float money);
        void MakeHistory(IAccount outAc, IAccount toAc, float money, ITransaction transaction);
        void CancelLastTransaction(IAccount account);
    }
}
