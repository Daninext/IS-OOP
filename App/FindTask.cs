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
    public partial class FindTask : Form
    {
        private TextBox _returnCommand;
        public FindTask(TextBox commandBox)
        {
            InitializeComponent();
            _returnCommand = commandBox;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            string command = "find task";

            if (idBox.Text != null && idBox.Text != string.Empty)
                command += " id=" + idBox.Text;
            if (createdTimeBox.Text != null && createdTimeBox.Text != string.Empty)
                command += " createdtime=" + createdTimeBox.Text;
            if (lastChangeTimeBox.Text != null && lastChangeTimeBox.Text != string.Empty)
                command += " lastchangetime=" + lastChangeTimeBox.Text;
            if (staffIdBox.Text != null && staffIdBox.Text != string.Empty)
                command += " staffid=" + staffIdBox.Text;
            if (lastStaffIdBox.Text != null && lastStaffIdBox.Text != string.Empty)
                command += " laststaffid=" + lastStaffIdBox.Text;
            if (byBossIdBox.Text != null && byBossIdBox.Text != string.Empty)
                command += " bybossid=" + byBossIdBox.Text;

            _returnCommand.Text = command;
        }
    }
}
