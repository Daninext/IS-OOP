namespace Banks.Services
{
    public class WithdrawType : ITransaction
    {
        public void CancelTransaction(AccountTransaction transaction)
        {
            transaction.OutAccount.Money.AddMoney(transaction.Money);
        }
    }
}
