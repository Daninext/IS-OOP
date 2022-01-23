
namespace App
{
    partial class FindTask
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
            this.findButton = new System.Windows.Forms.Button();
            this.idBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.staffIdLabel = new System.Windows.Forms.Label();
            this.byBossIdLabel = new System.Windows.Forms.Label();
            this.lastChangeTimeLabel = new System.Windows.Forms.Label();
            this.lastStaffIdLabel = new System.Windows.Forms.Label();
            this.createdTimeLabel = new System.Windows.Forms.Label();
            this.lastChangeTimeBox = new System.Windows.Forms.TextBox();
            this.staffIdBox = new System.Windows.Forms.TextBox();
            this.lastStaffIdBox = new System.Windows.Forms.TextBox();
            this.byBossIdBox = new System.Windows.Forms.TextBox();
            this.createdTimeBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(238, 259);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(98, 29);
            this.findButton.TabIndex = 19;
            this.findButton.Text = "Find task";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // idBox
            // 
            this.idBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idBox.Location = new System.Drawing.Point(157, 54);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(155, 24);
            this.idBox.TabIndex = 18;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idLabel.Location = new System.Drawing.Point(12, 57);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(26, 18);
            this.idLabel.TabIndex = 17;
            this.idLabel.Text = "ID:";
            // 
            // Info
            // 
            this.Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(348, 33);
            this.Info.TabIndex = 16;
            this.Info.Text = "Find task";
            this.Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // staffIdLabel
            // 
            this.staffIdLabel.AutoSize = true;
            this.staffIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.staffIdLabel.Location = new System.Drawing.Point(12, 147);
            this.staffIdLabel.Name = "staffIdLabel";
            this.staffIdLabel.Size = new System.Drawing.Size(60, 18);
            this.staffIdLabel.TabIndex = 20;
            this.staffIdLabel.Text = "Staff ID:";
            // 
            // byBossIdLabel
            // 
            this.byBossIdLabel.AutoSize = true;
            this.byBossIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.byBossIdLabel.Location = new System.Drawing.Point(12, 207);
            this.byBossIdLabel.Name = "byBossIdLabel";
            this.byBossIdLabel.Size = new System.Drawing.Size(84, 18);
            this.byBossIdLabel.TabIndex = 21;
            this.byBossIdLabel.Text = "By boss ID:";
            // 
            // lastChangeTimeLabel
            // 
            this.lastChangeTimeLabel.AutoSize = true;
            this.lastChangeTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastChangeTimeLabel.Location = new System.Drawing.Point(12, 117);
            this.lastChangeTimeLabel.Name = "lastChangeTimeLabel";
            this.lastChangeTimeLabel.Size = new System.Drawing.Size(124, 18);
            this.lastChangeTimeLabel.TabIndex = 22;
            this.lastChangeTimeLabel.Text = "Last change time:";
            // 
            // lastStaffIdLabel
            // 
            this.lastStaffIdLabel.AutoSize = true;
            this.lastStaffIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastStaffIdLabel.Location = new System.Drawing.Point(12, 177);
            this.lastStaffIdLabel.Name = "lastStaffIdLabel";
            this.lastStaffIdLabel.Size = new System.Drawing.Size(90, 18);
            this.lastStaffIdLabel.TabIndex = 23;
            this.lastStaffIdLabel.Text = "Last staff ID:";
            // 
            // createdTimeLabel
            // 
            this.createdTimeLabel.AutoSize = true;
            this.createdTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createdTimeLabel.Location = new System.Drawing.Point(12, 87);
            this.createdTimeLabel.Name = "createdTimeLabel";
            this.createdTimeLabel.Size = new System.Drawing.Size(96, 18);
            this.createdTimeLabel.TabIndex = 24;
            this.createdTimeLabel.Text = "Created time:";
            // 
            // lastChangeTimeBox
            // 
            this.lastChangeTimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastChangeTimeBox.Location = new System.Drawing.Point(157, 114);
            this.lastChangeTimeBox.Name = "lastChangeTimeBox";
            this.lastChangeTimeBox.Size = new System.Drawing.Size(155, 24);
            this.lastChangeTimeBox.TabIndex = 25;
            // 
            // staffIdBox
            // 
            this.staffIdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.staffIdBox.Location = new System.Drawing.Point(157, 144);
            this.staffIdBox.Name = "staffIdBox";
            this.staffIdBox.Size = new System.Drawing.Size(155, 24);
            this.staffIdBox.TabIndex = 26;
            // 
            // lastStaffIdBox
            // 
            this.lastStaffIdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastStaffIdBox.Location = new System.Drawing.Point(157, 174);
            this.lastStaffIdBox.Name = "lastStaffIdBox";
            this.lastStaffIdBox.Size = new System.Drawing.Size(155, 24);
            this.lastStaffIdBox.TabIndex = 27;
            // 
            // byBossIdBox
            // 
            this.byBossIdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.byBossIdBox.Location = new System.Drawing.Point(157, 204);
            this.byBossIdBox.Name = "byBossIdBox";
            this.byBossIdBox.Size = new System.Drawing.Size(155, 24);
            this.byBossIdBox.TabIndex = 28;
            // 
            // createdTimeBox
            // 
            this.createdTimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createdTimeBox.Location = new System.Drawing.Point(157, 84);
            this.createdTimeBox.Name = "createdTimeBox";
            this.createdTimeBox.Size = new System.Drawing.Size(155, 24);
            this.createdTimeBox.TabIndex = 29;
            // 
            // FindTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 300);
            this.Controls.Add(this.createdTimeBox);
            this.Controls.Add(this.byBossIdBox);
            this.Controls.Add(this.lastStaffIdBox);
            this.Controls.Add(this.staffIdBox);
            this.Controls.Add(this.lastChangeTimeBox);
            this.Controls.Add(this.createdTimeLabel);
            this.Controls.Add(this.lastStaffIdLabel);
            this.Controls.Add(this.lastChangeTimeLabel);
            this.Controls.Add(this.byBossIdLabel);
            this.Controls.Add(this.staffIdLabel);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.Info);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(366, 347);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(366, 347);
            this.Name = "FindTask";
            this.ShowIcon = false;
            this.Text = "Find task";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label staffIdLabel;
        private System.Windows.Forms.Label byBossIdLabel;
        private System.Windows.Forms.Label lastChangeTimeLabel;
        private System.Windows.Forms.Label lastStaffIdLabel;
        private System.Windows.Forms.Label createdTimeLabel;
        private System.Windows.Forms.TextBox lastChangeTimeBox;
        private System.Windows.Forms.TextBox staffIdBox;
        private System.Windows.Forms.TextBox lastStaffIdBox;
        private System.Windows.Forms.TextBox byBossIdBox;
        private System.Windows.Forms.TextBox createdTimeBox;
    }
}