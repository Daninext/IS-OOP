namespace Banks.Services
{
    public class DepositType : ITransaction
    {
        public void CancelTransaction(AccountTransaction transaction)
        {
            transaction.OutAccount.Money.AddMoney(-transaction.Money);
        }
    }
}
