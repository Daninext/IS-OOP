
namespace App
{
    partial class SetTask
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
            this.setButton = new System.Windows.Forms.Button();
            this.taskIdBox = new System.Windows.Forms.TextBox();
            this.taskIdLabel = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.staffIdLabel = new System.Windows.Forms.Label();
            this.staffIdBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(114, 116);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(98, 29);
            this.setButton.TabIndex = 19;
            this.setButton.Text = "Set task";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // taskIdBox
            // 
            this.taskIdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.taskIdBox.Location = new System.Drawing.Point(81, 39);
            this.taskIdBox.Name = "taskIdBox";
            this.taskIdBox.Size = new System.Drawing.Size(117, 24);
            this.taskIdBox.TabIndex = 18;
            // 
            // taskIdLabel
            // 
            this.taskIdLabel.AutoSize = true;
            this.taskIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.taskIdLabel.Location = new System.Drawing.Point(12, 42);
            this.taskIdLabel.Name = "taskIdLabel";
            this.taskIdLabel.Size = new System.Drawing.Size(63, 18);
            this.taskIdLabel.TabIndex = 17;
            this.taskIdLabel.Text = "Task ID:";
            // 
            // Info
            // 
            this.Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(224, 33);
            this.Info.TabIndex = 16;
            this.Info.Text = "Set task for staff";
            this.Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // staffIdLabel
            // 
            this.staffIdLabel.AutoSize = true;
            this.staffIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.staffIdLabel.Location = new System.Drawing.Point(12, 72);
            this.staffIdLabel.Name = "staffIdLabel";
            this.staffIdLabel.Size = new System.Drawing.Size(60, 18);
            this.staffIdLabel.TabIndex = 20;
            this.staffIdLabel.Text = "Staff ID:";
            // 
            // staffIdBox
            // 
            this.staffIdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.staffIdBox.Location = new System.Drawing.Point(81, 69);
            this.staffIdBox.Name = "staffIdBox";
            this.staffIdBox.Size = new System.Drawing.Size(117, 24);
            this.staffIdBox.TabIndex = 21;
            // 
            // SetTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 157);
            this.Controls.Add(this.staffIdBox);
            this.Controls.Add(this.staffIdLabel);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.taskIdBox);
            this.Controls.Add(this.taskIdLabel);
            this.Controls.Add(this.Info);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(242, 204);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(242, 204);
            this.Name = "SetTask";
            this.ShowIcon = false;
            this.Text = "Set task for staff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.TextBox taskIdBox;
        private System.Windows.Forms.Label taskIdLabel;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label staffIdLabel;
        private System.Windows.Forms.TextBox staffIdBox;
    }
}