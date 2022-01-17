using System;
using System.Windows.Forms;

namespace App
{
    public partial class FindStaff : Form
    {
        private TextBox _returnCommand;
        public FindStaff(TextBox commandBox)
        {
            InitializeComponent();
            _returnCommand = commandBox;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            _returnCommand.Text = "find staff id=" + idBox.Text;
        }
    }
}
