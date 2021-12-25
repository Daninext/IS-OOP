namespace Banks.Services
{
    public interface IAccount
    {
        public void DepositMoney(long money);
        public void WithdrawMoney(long money);
        public void Transaction(long money, IAccount account);
    }
}
