using System;
using System.Windows.Forms;

namespace App
{
    public partial class CreateStaff : Form
    {
        private TextBox _returnCommand;
        public CreateStaff(short id, TextBox commandBox)
        {
            InitializeComponent();
            _returnCommand = commandBox;
            bossIdBox.Text = id.ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _returnCommand.Text = "create staff name=" + nameBox.Text + " password=" + passBox.Text + " bossid=" + bossIdBox.Text;
        }
    }
}
