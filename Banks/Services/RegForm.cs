using Banks.Tools;

namespace Banks.Services
{
    public class RegForm
    {
        private string _fname;
        private string _sname;
        private string _passportNum;

        public RegForm(string fname, string sname, string passportNum)
        {
            FName = fname;
            SName = sname;
            PassportNum = passportNum;
        }

        public string FName
        {
            get => _fname;
            private set
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                        throw new InvalidRegDataBanksException("Invalid first name");
                }

                _fname = value;
            }
        }

        public string SName
        {
            get => _sname;
            private set
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c))
                        throw new InvalidRegDataBanksException("Invalid second name");
                }

                _sname = value;
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

        public bool IsConfirmed()
        {
            if (Telephone != string.Empty && Address != string.Empty)
                return true;

            return false;
        }
    }
}
