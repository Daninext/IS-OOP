namespace Banks.Services
{
    public interface IAccount
    {
        RealMoney Money { get; }
        void DepositMoney(float money);
        void WithdrawMoney(float money);
        void Transfer(float money, IAccount account);
        void Capitalize();
        void CalculateExtraMoney();
        float ShowMoney();
    }
}
