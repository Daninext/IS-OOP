using System;
using System.Windows.Forms;
using System.Text.Json;
using App.Services;
using Converter.JsonTemplate;
using Converter.SystemTemplate;

namespace App
{
    public partial class MenuForm : Form
    {
        private short _myID;
        private string _pass;
        private AppClient _client;
        private ReportTemplate _report;

        private CreateStaff _createStaff;
        private CreateTask _createTask;
        private FindStaff _findStaff;
        private FindTask _findTask;
        private SetTask _setTask;
        private ReportTable _reportTable;

        private bool _waitForAnswer;

        public MenuForm(short ID, string pass)
        {
            _myID = ID;
            _pass = pass;
            _client = new AppClient(this);
            InitializeComponent();

            IDLabel.Text = _myID.ToString();

            _createStaff = new CreateStaff(_myID, commandBox);
            _createTask = new CreateTask(commandBox);
            _findStaff = new FindStaff(commandBox);
            _findTask = new FindTask(commandBox);
            _setTask = new SetTask(commandBox);
            _reportTable = new ReportTable(_client, this);
        }

        public void ProcessMessage(string message)
        {
            string[] args = message.Split(' ');

            if (args[0] != "system")
                Invoke(new Action(() =>
                {
                    WriteHistory("s > " + message);
                }));
            
            switch (args[1])
            {
                case "report":
                    _report = JsonSerializer.Deserialize<ReportTemplate>(args[args.Length - 1]);
                    _waitForAnswer = false;
                    break;
            }
        }

        public void SendReport(ReportTemplate report)
        {
            _client.SendMessage("update report name=" + report.name
                + " staffid=" + _myID.ToString()
                + " type=" + report.type
                + " comment=" + report.comment
                + " resolve=" + report.resolve
                + "|id=" + _myID.ToString() 
                + " password=" + _pass, 2);
        }

        private void WriteHistory(string message)
        {
            message = message.Replace("\n", Environment.NewLine);
            historyBox.AppendText(message + " Time: " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
            var auth = new Authorization();
            auth.Show();
        }

        private void sendCommandBottun_Click(object sender, EventArgs e)
        {
            string message = commandBox.Text;
            WriteHistory("c > " + message);

            message += "|id=" + _myID.ToString() + " password=" + _pass;
            _client.SendMessage(message, 2);
        }

        private void createStaffButton_Click(object sender, EventArgs e)
        {
            if (_createStaff.IsDisposed)
                _createStaff = new CreateStaff(_myID, commandBox);
            _createStaff.Show();
        }

        private void createTaskButton_Click(object sender, EventArgs e)
        {
            if (_createTask.IsDisposed)
                _createTask = new CreateTask(commandBox);
            _createTask.Show();
        }

        private void findStaffButton_Click(object sender, EventArgs e)
        {
            if (_findStaff.IsDisposed)
                _findStaff = new FindStaff(commandBox);
            _findStaff.Show();
        }

        private void findTaskButton_Click(object sender, EventArgs e)
        {
            if (_findTask.IsDisposed)
                _findTask = new FindTask(commandBox);
            _findTask.Show();
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _createStaff.Close();
            _createTask.Close();
            _findStaff.Close();
            _findTask.Close();
            _setTask.Close();
            _reportTable.Close();
        }

        private void updateTaskButton_Click(object sender, EventArgs e)
        {
            commandBox.Text = "update task comment=" + commentBox.Text.Replace(" ", "^&").Replace(Environment.NewLine, "\\n");
        }

        private void setTaskButton_Click(object sender, EventArgs e)
        {
            if (_setTask.IsDisposed)
                _setTask = new SetTask(commandBox);
            _setTask.Show();
        }

        private void resolveTaskButton_Click(object sender, EventArgs e)
        {
            commandBox.Text = "resolve task";
        }

        private async void GetReport(string type)
        {
            _waitForAnswer = true;
            _client.SendMessage("find report write staffid=" + _myID.ToString()
                + " type=" + type 
                + " resolve=false" + "|id=" + _myID.ToString()
                + " password=" + _pass, 3);

            await System.Threading.Tasks.Task.Run(() => { while (_waitForAnswer) ; });

            if (_reportTable.IsDisposed)
                _reportTable = new ReportTable(_client, this);

            if (_report.intStaffid == 0)
            {
                _client.SendMessage("create report staffid=" + _myID.ToString()
                    + " type=daily"
                    + "|id=" + _myID.ToString()
                    + " password=" + _pass, 2);

                _report = new ReportTemplate();
                _report.intStaffid = _myID;
                _report.type = type;
            }

            if (_report.name != null)
                _report.name.Replace("^&", " ");
            if (_report.comment != null)
                _report.comment.Replace("^&", " ");
            _reportTable.LoadReport(_report);
            _reportTable.Show();
        }

        private void openReportButton_Click(object sender, EventArgs e)
        {
            if (reportMode.CheckedItems.Count != 0)
                GetReport(reportMode.CheckedItems[0].ToString());
        }

        private void reportFromStaffButton_Click(object sender, EventArgs e)
        {
            if (reportMode.CheckedItems.Count != 0)
                _client.SendMessage("find report read type=" + reportMode.CheckedItems[0].ToString()
                    + " resolve=true"
                    + "|id=" + _myID.ToString()
                    + " password=" + _pass, 3);
        }

        private void reportMode_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var list = sender as CheckedListBox;
            if (e.NewValue == CheckState.Checked)
                foreach (int index in list.CheckedIndices)
                    if (index != e.Index)
                        list.SetItemChecked(index, false);
        }
    }
}
