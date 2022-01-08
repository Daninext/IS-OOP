using System;
using System.Windows.Forms;

namespace App
{
    public partial class SetTask : Form
    {
        private TextBox _returnCommand;
        public SetTask(TextBox commandBox)
        {
            InitializeComponent();
            _returnCommand = commandBox;
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            _returnCommand.Text = "set task id=" + taskIdBox.Text + " staffid=" + staffIdBox.Text;
        }
    }
}
