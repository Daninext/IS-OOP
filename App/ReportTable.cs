using System;
using System.Windows.Forms;
using App.Services;
using Converter.JsonTemplate;
using Converter.SystemTemplate;

namespace App
{
    public partial class ReportTable : Form
    {
        private AppClient _client;
        private MenuForm _menu;

        public ReportTable(AppClient client, MenuForm menu)
        {
            _client = client;
            _menu = menu;
            InitializeComponent();
        }

        public void LoadReport(ReportTemplate report)
        {
            nameBox.Text = report.name;
            typeLabel.Text = report.type;
            commentBox.Text = report.comment;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            var newReport = new ReportTemplate();
            newReport.name = nameBox.Text.Replace(" ", "^&");
            newReport.type = typeLabel.Text;
            newReport.comment = commentBox.Text.Replace(" ", "^&").Replace(Environment.NewLine, "\\n");
            newReport.boolResolve = resolveBox.Checked;

            _menu.SendReport(newReport);
            Close();
        }
    }
}
