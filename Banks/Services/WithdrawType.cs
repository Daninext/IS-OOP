namespace Banks.Services
{
    public class WithdrawType : ITransaction
    {
        public void CancelTransaction(IAccount outAccount, IAccount toAccount, long money)
        {
            outAccount.DepositMoney(money);
        }
    }
}
