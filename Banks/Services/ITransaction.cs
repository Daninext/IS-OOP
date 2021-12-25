namespace Banks.Services
{
    public interface ITransaction
    {
        public void CancelTransaction(IAccount outAccount, IAccount toAccount, long money);
    }
}
