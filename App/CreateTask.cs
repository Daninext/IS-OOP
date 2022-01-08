using System;
using System.Windows.Forms;

namespace App
{
    public partial class CreateTask : Form
    {
        private TextBox _returnCommand;
        public CreateTask(TextBox commandBox)
        {
            InitializeComponent();
            _returnCommand = commandBox;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _returnCommand.Text = "create task target=" + targetBox.Text.Replace(" ", "^&") + " needsecuritylevel=" + securityLevelBox.Text;
        }
    }
}
