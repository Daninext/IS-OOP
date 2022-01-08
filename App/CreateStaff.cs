using System;
using System.Windows.Forms;

namespace App
{
    public partial class CreateStaff : Form
    {
        private TextBox _returnCommand;
        public CreateStaff(short ID, TextBox commandBox)
        {
            InitializeComponent();
            _returnCommand = commandBox;
            bossIdBox.Text = ID.ToString();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _returnCommand.Text = "create staff name=" + nameBox.Text + " password=" + passBox.Text + " bossid=" + bossIdBox.Text;
        }
    }
}
