namespace Banks.Services
{
    public class TransferType : ITransaction
    {
        public void CancelTransaction(AccountTransaction transaction)
        {
            transaction.OutAccount.Money.AddMoney(transaction.Money);
            transaction.ToAccount.Money.AddMoney(-transaction.Money);
        }
    }
}
