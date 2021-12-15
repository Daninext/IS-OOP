namespace Banks.Services
{
    public interface ICentralBank
    {
        public Bank RegBank(string name);
        public Bank FindBank(string name);
        public void CapTime(int days);
        public void TransactionMoney(IAccount outAc, IAccount toAc, long money);
        public void MakeHistory(IAccount outAc, IAccount toAc, long money, string type);
        public void CancelLastTransaction(IAccount account);
    }
}
