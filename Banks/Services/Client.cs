using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Banks.Services
{
    public class Client
    {
        private List<IAccount> _accounts = new List<IAccount>();

        public Client(RegFormBuilder form, Bank bank)
        {
            FormBuilder = form;
            MainBank = bank;
        }

        public RegFormBuilder FormBuilder { get; private set; }

        public IReadOnlyList<IAccount> Accounts => _accounts;

        public Bank MainBank { get; }

        public void CreateDebitAc(float percentages, long startMoney = 0)
        {
            _accounts.Add(new Debit(this, percentages, startMoney));
        }

        public void CreateCreditAc(float fee, long startMoney = 0)
        {
            _accounts.Add(new Credit(this, fee, startMoney));
        }

        public void CreateDepositAc(DateTime endAcTime, DinPercentages percentages, long startMoney = 0)
        {
            _accounts.Add(new Deposit(this, endAcTime, percentages, startMoney));
        }

        public void ChangeDebitPers(float newPers)
        {
            foreach (Debit account in _accounts)
            {
                account.ChangePercentages(newPers);
            }

            Notification("This is a percentages change notification", "We have changed percentages on your debit accounts. Now it is " + newPers.ToString());
        }

        public void ChangeCreditFee(float newFee)
        {
            foreach (Credit account in _accounts)
            {
                account.ChangeFee(newFee);
            }

            Notification("This is a percentages change notification", "We have changed fee on your credit accounts. Now it is " + newFee.ToString());
        }

        private void Notification(string subject, string body)
        {
            if (FormBuilder.Form.Email != null)
            {
                var message = new MailMessage(MainBank.BankEmail, FormBuilder.Form.Email);

                message.Subject = subject;
                message.Body = body;

                var client = new SmtpClient(MainBank.SMTP);
                client.Credentials = CredentialCache.DefaultNetworkCredentials;
                client.Send(message);
            }
        }
    }
}
