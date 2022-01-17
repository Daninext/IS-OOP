
namespace App
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.infoIDLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.historyBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sendCommandBottun = new System.Windows.Forms.Button();
            this.createStaffButton = new System.Windows.Forms.Button();
            this.createTaskButton = new System.Windows.Forms.Button();
            this.findStaffButton = new System.Windows.Forms.Button();
            this.findTaskButton = new System.Windows.Forms.Button();
            this.commentBox = new System.Windows.Forms.TextBox();
            this.commentLabel = new System.Windows.Forms.Label();
            this.updateTaskButton = new System.Windows.Forms.Button();
            this.setTaskButton = new System.Windows.Forms.Button();
            this.resolveTaskButton = new System.Windows.Forms.Button();
            this.openReportButton = new System.Windows.Forms.Button();
            this.staffLabel = new System.Windows.Forms.Label();
            this.taskLabel = new System.Windows.Forms.Label();
            this.reportLabel = new System.Windows.Forms.Label();
            this.reportFromStaffButton = new System.Windows.Forms.Button();
            this.reportMode = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoIDLabel
            // 
            this.infoIDLabel.AutoSize = true;
            this.infoIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoIDLabel.Location = new System.Drawing.Point(12, 9);
            this.infoIDLabel.Name = "infoIDLabel";
            this.infoIDLabel.Size = new System.Drawing.Size(150, 25);
            this.infoIDLabel.TabIndex = 0;
            this.infoIDLabel.Text = "Your system ID:";
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IDLabel.Location = new System.Drawing.Point(168, 9);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(0, 25);
            this.IDLabel.TabIndex = 1;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(713, 6);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 27);
            this.logoutButton.TabIndex = 2;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.commandBox);
            this.panel1.Controls.Add(this.historyBox);
            this.panel1.Location = new System.Drawing.Point(404, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 365);
            this.panel1.TabIndex = 3;
            // 
            // commandBox
            // 
            this.commandBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commandBox.Location = new System.Drawing.Point(0, 338);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(384, 27);
            this.commandBox.TabIndex = 1;
            // 
            // historyBox
            // 
            this.historyBox.AcceptsReturn = true;
            this.historyBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.historyBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.historyBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.historyBox.Location = new System.Drawing.Point(0, 0);
            this.historyBox.MaxLength = 100000;
            this.historyBox.Multiline = true;
            this.historyBox.Name = "historyBox";
            this.historyBox.ReadOnly = true;
            this.historyBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.historyBox.Size = new System.Drawing.Size(384, 341);
            this.historyBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(401, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server answer:";
            // 
            // sendCommandBottun
            // 
            this.sendCommandBottun.Location = new System.Drawing.Point(688, 411);
            this.sendCommandBottun.Name = "sendCommandBottun";
            this.sendCommandBottun.Size = new System.Drawing.Size(100, 33);
            this.sendCommandBottun.TabIndex = 5;
            this.sendCommandBottun.Text = "Send";
            this.sendCommandBottun.UseVisualStyleBackColor = true;
            this.sendCommandBottun.Click += new System.EventHandler(this.SendCommandBottun_Click);
            // 
            // createStaffButton
            // 
            this.createStaffButton.Location = new System.Drawing.Point(23, 73);
            this.createStaffButton.Name = "createStaffButton";
            this.createStaffButton.Size = new System.Drawing.Size(106, 30);
            this.createStaffButton.TabIndex = 6;
            this.createStaffButton.Text = "Add staff";
            this.createStaffButton.UseVisualStyleBackColor = true;
            this.createStaffButton.Click += new System.EventHandler(this.CreateStaffButton_Click);
            // 
            // createTaskButton
            // 
            this.createTaskButton.Location = new System.Drawing.Point(133, 73);
            this.createTaskButton.Name = "createTaskButton";
            this.createTaskButton.Size = new System.Drawing.Size(106, 30);
            this.createTaskButton.TabIndex = 7;
            this.createTaskButton.Text = "Add task";
            this.createTaskButton.UseVisualStyleBackColor = true;
            this.createTaskButton.Click += new System.EventHandler(this.CreateTaskButton_Click);
            // 
            // findStaffButton
            // 
            this.findStaffButton.Location = new System.Drawing.Point(23, 109);
            this.findStaffButton.Name = "findStaffButton";
            this.findStaffButton.Size = new System.Drawing.Size(106, 30);
            this.findStaffButton.TabIndex = 8;
            this.findStaffButton.Text = "Find staff";
            this.findStaffButton.UseVisualStyleBackColor = true;
            this.findStaffButton.Click += new System.EventHandler(this.FindStaffButton_Click);
            // 
            // findTaskButton
            // 
            this.findTaskButton.Location = new System.Drawing.Point(133, 109);
            this.findTaskButton.Name = "findTaskButton";
            this.findTaskButton.Size = new System.Drawing.Size(106, 30);
            this.findTaskButton.TabIndex = 9;
            this.findTaskButton.Text = "Find task";
            this.findTaskButton.UseVisualStyleBackColor = true;
            this.findTaskButton.Click += new System.EventHandler(this.FindTaskButton_Click);
            // 
            // commentBox
            // 
            this.commentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commentBox.Location = new System.Drawing.Point(17, 259);
            this.commentBox.Multiline = true;
            this.commentBox.Name = "commentBox";
            this.commentBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.commentBox.Size = new System.Drawing.Size(343, 144);
            this.commentBox.TabIndex = 10;
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commentLabel.Location = new System.Drawing.Point(13, 236);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(86, 20);
            this.commentLabel.TabIndex = 11;
            this.commentLabel.Text = "Comment:";
            // 
            // updateTaskButton
            // 
            this.updateTaskButton.Location = new System.Drawing.Point(17, 408);
            this.updateTaskButton.Name = "updateTaskButton";
            this.updateTaskButton.Size = new System.Drawing.Size(151, 30);
            this.updateTaskButton.TabIndex = 12;
            this.updateTaskButton.Text = "Update task";
            this.updateTaskButton.UseVisualStyleBackColor = true;
            this.updateTaskButton.Click += new System.EventHandler(this.UpdateTaskButton_Click);
            // 
            // setTaskButton
            // 
            this.setTaskButton.Location = new System.Drawing.Point(133, 145);
            this.setTaskButton.Name = "setTaskButton";
            this.setTaskButton.Size = new System.Drawing.Size(106, 29);
            this.setTaskButton.TabIndex = 13;
            this.setTaskButton.Text = "Set task";
            this.setTaskButton.UseVisualStyleBackColor = true;
            this.setTaskButton.Click += new System.EventHandler(this.SetTaskButton_Click);
            // 
            // resolveTaskButton
            // 
            this.resolveTaskButton.Location = new System.Drawing.Point(133, 180);
            this.resolveTaskButton.Name = "resolveTaskButton";
            this.resolveTaskButton.Size = new System.Drawing.Size(106, 29);
            this.resolveTaskButton.TabIndex = 14;
            this.resolveTaskButton.Text = "Resolve task";
            this.resolveTaskButton.UseVisualStyleBackColor = true;
            this.resolveTaskButton.Click += new System.EventHandler(this.ResolveTaskButton_Click);
            // 
            // openReportButton
            // 
            this.openReportButton.Location = new System.Drawing.Point(246, 145);
            this.openReportButton.Name = "openReportButton";
            this.openReportButton.Size = new System.Drawing.Size(106, 30);
            this.openReportButton.TabIndex = 15;
            this.openReportButton.Text = "Open";
            this.openReportButton.UseVisualStyleBackColor = true;
            this.openReportButton.Click += new System.EventHandler(this.OpenReportButton_Click);
            // 
            // staffLabel
            // 
            this.staffLabel.AutoSize = true;
            this.staffLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.staffLabel.Location = new System.Drawing.Point(55, 40);
            this.staffLabel.Name = "staffLabel";
            this.staffLabel.Size = new System.Drawing.Size(44, 24);
            this.staffLabel.TabIndex = 18;
            this.staffLabel.Text = "Staff";
            // 
            // taskLabel
            // 
            this.taskLabel.AutoSize = true;
            this.taskLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.taskLabel.Location = new System.Drawing.Point(158, 40);
            this.taskLabel.Name = "taskLabel";
            this.taskLabel.Size = new System.Drawing.Size(50, 24);
            this.taskLabel.TabIndex = 19;
            this.taskLabel.Text = "Task";
            // 
            // reportLabel
            // 
            this.reportLabel.AutoSize = true;
            this.reportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportLabel.Location = new System.Drawing.Point(266, 40);
            this.reportLabel.Name = "reportLabel";
            this.reportLabel.Size = new System.Drawing.Size(66, 24);
            this.reportLabel.TabIndex = 20;
            this.reportLabel.Text = "Report";
            // 
            // reportFromStaffButton
            // 
            this.reportFromStaffButton.Location = new System.Drawing.Point(246, 181);
            this.reportFromStaffButton.Name = "reportFromStaffButton";
            this.reportFromStaffButton.Size = new System.Drawing.Size(106, 28);
            this.reportFromStaffButton.TabIndex = 21;
            this.reportFromStaffButton.Text = "Get";
            this.reportFromStaffButton.UseVisualStyleBackColor = true;
            this.reportFromStaffButton.Click += new System.EventHandler(this.ReportFromStaffButton_Click);
            // 
            // reportMode
            // 
            this.reportMode.BackColor = System.Drawing.SystemColors.MenuBar;
            this.reportMode.FormattingEnabled = true;
            this.reportMode.Items.AddRange(new object[] {
            "daily",
            "weekly",
            "sprint"});
            this.reportMode.Location = new System.Drawing.Point(257, 73);
            this.reportMode.Name = "reportMode";
            this.reportMode.Size = new System.Drawing.Size(84, 72);
            this.reportMode.TabIndex = 3;
            this.reportMode.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ReportMode_ItemCheck);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportMode);
            this.Controls.Add(this.reportFromStaffButton);
            this.Controls.Add(this.reportLabel);
            this.Controls.Add(this.taskLabel);
            this.Controls.Add(this.staffLabel);
            this.Controls.Add(this.openReportButton);
            this.Controls.Add(this.resolveTaskButton);
            this.Controls.Add(this.setTaskButton);
            this.Controls.Add(this.updateTaskButton);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.commentBox);
            this.Controls.Add(this.findTaskButton);
            this.Controls.Add(this.findStaffButton);
            this.Controls.Add(this.createTaskButton);
            this.Controls.Add(this.createStaffButton);
            this.Controls.Add(this.sendCommandBottun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.infoIDLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuForm";
            this.ShowIcon = false;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoIDLabel;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox historyBox;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.Button sendCommandBottun;
        private System.Windows.Forms.Button createStaffButton;
        private System.Windows.Forms.Button createTaskButton;
        private System.Windows.Forms.Button findStaffButton;
        private System.Windows.Forms.Button findTaskButton;
        private System.Windows.Forms.TextBox commentBox;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.Button updateTaskButton;
        private System.Windows.Forms.Button setTaskButton;
        private System.Windows.Forms.Button resolveTaskButton;
        private System.Windows.Forms.Button openReportButton;
        private System.Windows.Forms.Label staffLabel;
        private System.Windows.Forms.Label taskLabel;
        private System.Windows.Forms.Label reportLabel;
        private System.Windows.Forms.Button reportFromStaffButton;
        private System.Windows.Forms.CheckedListBox reportMode;
    }
}