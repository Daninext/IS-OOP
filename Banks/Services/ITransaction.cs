namespace Banks.Services
{
    public interface ITransaction
    {
        void CancelTransaction(AccountTransaction transaction);
    }
}
