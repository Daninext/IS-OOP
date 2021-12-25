namespace Banks.Services
{
    public class DepositType : ITransaction
    {
        public void CancelTransaction(IAccount outAccount, IAccount toAccount, long money)
        {
            outAccount.WithdrawMoney(money);
        }
    }
}
