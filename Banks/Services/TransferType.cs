namespace Banks.Services
{
    public class TransferType : ITransaction
    {
        public void CancelTransaction(IAccount outAccount, IAccount toAccount, long money)
        {
            outAccount.DepositMoney(money);
            toAccount.WithdrawMoney(money);
        }
    }
}
