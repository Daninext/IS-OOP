using System;
using System.Windows.Forms;
using App.Services;

namespace App
{
    public partial class Authorization : Form
    {
        private AppClient _client;

        public Authorization()
        {
            _client = new AppClient(this);
            InitializeComponent();
        }

        public void ProcessMessage(string message)
        {
            string[] args = message.Split(' ');

            if (args[0] != "success")
            {
                MessageBox.Show("Invalid login/password");
                return;
            }

            Invoke(new Action(() =>
                {
                    Hide();
                    var menu = new MenuForm(Convert.ToInt16(args[1]), passBox.Text);
                    menu.Show();
                }));
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            _client.SendMessage("auth staff name=" + loginBox.Text + " password=" + passBox.Text + "|", 2);
        }
    }
}
