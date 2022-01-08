
namespace App
{
    partial class CreateTask
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
            this.addButton = new System.Windows.Forms.Button();
            this.targetBox = new System.Windows.Forms.TextBox();
            this.targetLabel = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.securityLavelLabel = new System.Windows.Forms.Label();
            this.securityLevelBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(285, 116);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(98, 29);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "Add task";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // targetBox
            // 
            this.targetBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.targetBox.Location = new System.Drawing.Point(72, 47);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(311, 24);
            this.targetBox.TabIndex = 12;
            // 
            // targetLabel
            // 
            this.targetLabel.AutoSize = true;
            this.targetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.targetLabel.Location = new System.Drawing.Point(12, 50);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(54, 18);
            this.targetLabel.TabIndex = 9;
            this.targetLabel.Text = "Target:";
            // 
            // Info
            // 
            this.Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(395, 33);
            this.Info.TabIndex = 8;
            this.Info.Text = "New task";
            this.Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // securityLavelLabel
            // 
            this.securityLavelLabel.AutoSize = true;
            this.securityLavelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.securityLavelLabel.Location = new System.Drawing.Point(12, 84);
            this.securityLavelLabel.Name = "securityLavelLabel";
            this.securityLavelLabel.Size = new System.Drawing.Size(98, 18);
            this.securityLavelLabel.TabIndex = 16;
            this.securityLavelLabel.Text = "Security level:";
            // 
            // securityLevelBox
            // 
            this.securityLevelBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.securityLevelBox.Location = new System.Drawing.Point(116, 81);
            this.securityLevelBox.Name = "securityLevelBox";
            this.securityLevelBox.Size = new System.Drawing.Size(53, 24);
            this.securityLevelBox.TabIndex = 17;
            // 
            // CreateTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 157);
            this.Controls.Add(this.securityLevelBox);
            this.Controls.Add(this.securityLavelLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.targetBox);
            this.Controls.Add(this.targetLabel);
            this.Controls.Add(this.Info);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(413, 204);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(413, 204);
            this.Name = "CreateTask";
            this.ShowIcon = false;
            this.Text = "Add new task";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox targetBox;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label securityLavelLabel;
        private System.Windows.Forms.TextBox securityLevelBox;
    }
}