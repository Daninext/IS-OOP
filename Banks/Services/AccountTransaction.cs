namespace Banks.Services
{
    public class AccountTransaction
    {
        public AccountTransaction(ITransaction transaction, IAccount outAccount, IAccount toAccount, float money)
        {
            Transaction = transaction;

            OutAccount = outAccount;
            ToAccount = toAccount;

            Money = money;
        }

        public ITransaction Transaction { get; }

        public IAccount OutAccount { get; }
        public IAccount ToAccount { get; }

        public float Money { get; }
    }
}
