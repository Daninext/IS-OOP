namespace Banks.Services
{
    public class AccountTransaction
    {
        public AccountTransaction(string transactionType, IAccount outAccount, IAccount toAccount, long money)
        {
            TransactionType = transactionType;

            OutAccount = outAccount;
            ToAccount = toAccount;

            Money = money;
        }

        public string TransactionType { get; }

        public IAccount OutAccount { get; }
        public IAccount ToAccount { get; }

        public long Money { get; }
    }
}
