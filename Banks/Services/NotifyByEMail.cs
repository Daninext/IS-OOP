using System.Net;
using System.Net.Mail;

namespace Banks.Services
{
    public class NotifyByEMail : INotification
    {
        public void Notify(Client client, string topic, string body)
        {
            if (client.FormBuilder.Form.Email != null)
            {
                var message = new MailMessage(client.MainBank.BankEmail, client.FormBuilder.Form.Email);

                message.Subject = topic;
                message.Body = body;

                var mailClient = new SmtpClient(client.MainBank.SMTP);
                mailClient.Credentials = CredentialCache.DefaultNetworkCredentials;
                mailClient.Send(message);
            }
        }
    }
}
