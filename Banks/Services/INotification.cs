namespace Banks.Services
{
    public interface INotification
    {
        void Notify(Client client, string topic, string body);
    }
}
