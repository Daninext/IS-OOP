﻿using System.Net.Mail;
using Banks.Tools;

namespace Banks.Services
{
    public class RegForm
    {
        private string _firstName;
        private string _secondName;
        private string _passportNum;

        public RegForm(string firstName, string secondName, string passportNum)
        {
            FirstName = firstName;
            SecondName = secondName;
            PassportNum = passportNum;
        }

        public string FirstName
        {
            get => _firstName;
            private set
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                        throw new InvalidRegDataBanksException("Invalid first name");
                }

                _firstName = value;
            }
        }

        public string SecondName
        {
            get => _secondName;
            private set
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                        throw new InvalidRegDataBanksException("Invalid second name");
                }

                _secondName = value;
            }
        }

        public string PassportNum
        {
            get => _passportNum;
            private set
            {
                foreach (char c in value)
                {
                    if (!char.IsDigit(c))
                        throw new InvalidRegDataBanksException("Invalid passport number");
                }

                _passportNum = value;
            }
        }

        public string Telephone { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public MailAddress Email { get; private set; } = null;

        public void ChangeTelephone(string tel)
        {
            if (tel != string.Empty && tel[0] == '+')
                tel = tel.Remove(0, 1);

            foreach (char c in tel)
            {
                if (!char.IsDigit(c))
                    throw new InvalidRegDataBanksException("Invalid tel number");
            }

            Telephone = tel;
        }

        public void ChangeAddress(string address)
        {
            Address = address;
        }

        public void ChangeEmail(string email)
        {
            MailAddress newEmail;
            if (!MailAddress.TryCreate(email, out newEmail))
                throw new InvalidRegDataBanksException("Invalid email");

            Email = newEmail;
        }

        public bool IsConfirmed()
        {
            if (Telephone != string.Empty && Address != string.Empty)
                return true;

            return false;
        }
    }
}
