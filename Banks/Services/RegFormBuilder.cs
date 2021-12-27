namespace Banks.Services
{
    public class RegFormBuilder
    {
        public RegFormBuilder(string fname, string sname, string passportNum)
        {
            Form = new RegForm(fname, sname, passportNum);
        }

        public RegForm Form { get; }

        public void AddTelephone(string telNumber)
        {
            Form.ChangeTelephone(telNumber);
        }

        public void AddAdress(string address)
        {
            Form.ChangeAddress(address);
        }

        public void AddEmail(string email)
        {
            Form.ChangeEmail(email);
        }
    }
}
