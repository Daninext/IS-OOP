
namespace App
{
    partial class CreateStaff
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
            this.Info = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.bossIdLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.passBox = new System.Windows.Forms.TextBox();
            this.bossIdBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(260, 33);
            this.Info.TabIndex = 0;
            this.Info.Text = "New staff";
            this.Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(12, 50);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(52, 18);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passLabel.Location = new System.Drawing.Point(12, 77);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(79, 18);
            this.passLabel.TabIndex = 2;
            this.passLabel.Text = "Password:";
            // 
            // bossIdLabel
            // 
            this.bossIdLabel.AutoSize = true;
            this.bossIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bossIdLabel.Location = new System.Drawing.Point(12, 104);
            this.bossIdLabel.Name = "bossIdLabel";
            this.bossIdLabel.Size = new System.Drawing.Size(65, 18);
            this.bossIdLabel.TabIndex = 3;
            this.bossIdLabel.Text = "Boss ID:";
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBox.Location = new System.Drawing.Point(107, 47);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(126, 24);
            this.nameBox.TabIndex = 4;
            // 
            // passBox
            // 
            this.passBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passBox.Location = new System.Drawing.Point(107, 74);
            this.passBox.Name = "passBox";
            this.passBox.Size = new System.Drawing.Size(126, 24);
            this.passBox.TabIndex = 5;
            // 
            // bossIdBox
            // 
            this.bossIdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bossIdBox.Location = new System.Drawing.Point(107, 101);
            this.bossIdBox.Name = "bossIdBox";
            this.bossIdBox.Size = new System.Drawing.Size(126, 24);
            this.bossIdBox.TabIndex = 6;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(150, 193);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(98, 29);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Add staff";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // CreateStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 234);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.bossIdBox);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.bossIdLabel);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.Info);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(278, 281);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(278, 281);
            this.Name = "CreateStaff";
            this.ShowIcon = false;
            this.Text = "Add new staff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label bossIdLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.TextBox bossIdBox;
        private System.Windows.Forms.Button addButton;
    }
}