using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void findButton_Click(object sender, EventArgs e)
        {
            _returnCommand.Text = "find staff id=" + idBox.Text;
        }
    }
}
