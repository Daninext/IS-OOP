using Banks.Tools;

namespace Banks.Services
{
    public class RegForm
    {
        public RegForm(string fname, string sname, string passportNum, string tel = "", string address = "")
        {
            foreach (char c in fname)
            {
                if (!char.IsLetter(c))
                    throw new InvalidRegDataBanksException("Invalid first name");
            }

            foreach (char c in sname)
            {
                if (!char.IsLetter(c))
                    throw new InvalidRegDataBanksException("Invalid second name");
            }

            foreach (char c in passportNum)
            {
                if (!char.IsDigit(c))
                    throw new InvalidRegDataBanksException("Invalid passport number");
            }

            FName = fname;
            SName = sname;
            PassportNum = passportNum;

            ChangeTelephone(tel);
            ChangeAddress(address);
        }

        public string FName { get; private set; }
        public string SName { get; private set; }
        public string PassportNum { get; private set; }
        public string Telephone { get; private set; }
        public string Address { get; private set; }
        public string Status { get; private set; }

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

            ChangeStatus();
        }

        public void ChangeAddress(string address)
        {
            Address = address;

            ChangeStatus();
        }

        private void ChangeStatus()
        {
            if (Telephone != string.Empty && Address != string.Empty)
            {
                Status = "Confirmed";
            }
            else
            {
                Status = "Unconfirmed";
            }
        }
    }
}
