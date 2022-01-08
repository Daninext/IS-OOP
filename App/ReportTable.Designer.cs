
namespace App
{
    partial class ReportTable
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.typeInfoLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.commentLabel = new System.Windows.Forms.Label();
            this.commentBox = new System.Windows.Forms.TextBox();
            this.resolveBox = new System.Windows.Forms.CheckBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(58, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameBox.Location = new System.Drawing.Point(76, 6);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(345, 27);
            this.nameBox.TabIndex = 1;
            // 
            // typeInfoLabel
            // 
            this.typeInfoLabel.AutoSize = true;
            this.typeInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeInfoLabel.Location = new System.Drawing.Point(12, 51);
            this.typeInfoLabel.Name = "typeInfoLabel";
            this.typeInfoLabel.Size = new System.Drawing.Size(50, 20);
            this.typeInfoLabel.TabIndex = 2;
            this.typeInfoLabel.Text = "Type:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeLabel.Location = new System.Drawing.Point(68, 51);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(0, 20);
            this.typeLabel.TabIndex = 3;
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commentLabel.Location = new System.Drawing.Point(12, 91);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(86, 20);
            this.commentLabel.TabIndex = 4;
            this.commentLabel.Text = "Comment:";
            // 
            // commentBox
            // 
            this.commentBox.Location = new System.Drawing.Point(16, 114);
            this.commentBox.Multiline = true;
            this.commentBox.Name = "commentBox";
            this.commentBox.Size = new System.Drawing.Size(405, 328);
            this.commentBox.TabIndex = 5;
            // 
            // resolveBox
            // 
            this.resolveBox.AutoSize = true;
            this.resolveBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resolveBox.Location = new System.Drawing.Point(16, 461);
            this.resolveBox.Name = "resolveBox";
            this.resolveBox.Size = new System.Drawing.Size(85, 24);
            this.resolveBox.TabIndex = 6;
            this.resolveBox.Text = "resolve";
            this.resolveBox.UseVisualStyleBackColor = true;
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendButton.Location = new System.Drawing.Point(339, 448);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(82, 37);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ReportTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 497);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.resolveBox);
            this.Controls.Add(this.commentBox);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.typeInfoLabel);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.nameLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(451, 544);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(451, 544);
            this.Name = "ReportTable";
            this.ShowIcon = false;
            this.Text = "ReportTable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label typeInfoLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.TextBox commentBox;
        private System.Windows.Forms.CheckBox resolveBox;
        private System.Windows.Forms.Button sendButton;
    }
}