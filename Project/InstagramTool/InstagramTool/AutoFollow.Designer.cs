﻿namespace InstagramTool
{
    partial class AutoFollow
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
            this.urlTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.autoFollowbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // urlTextBox
            // 
            this.urlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlTextBox.Location = new System.Drawing.Point(12, 96);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(1120, 598);
            this.urlTextBox.TabIndex = 1;
            this.urlTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập URL của tài khoản cần follow";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "(Mỗi tài khoản 1 dòng)";
            // 
            // autoFollowbtn
            // 
            this.autoFollowbtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.autoFollowbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoFollowbtn.Location = new System.Drawing.Point(860, 16);
            this.autoFollowbtn.Name = "autoFollowbtn";
            this.autoFollowbtn.Size = new System.Drawing.Size(166, 60);
            this.autoFollowbtn.TabIndex = 4;
            this.autoFollowbtn.Text = "Auto Follow";
            this.autoFollowbtn.UseVisualStyleBackColor = false;
            this.autoFollowbtn.Click += new System.EventHandler(this.autoFollowbtn_Click);
            // 
            // AutoFollow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 706);
            this.Controls.Add(this.autoFollowbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.urlTextBox);
            this.Name = "AutoFollow";
            this.Text = "AutoFollow";
            this.Activated += new System.EventHandler(this.AutoFl_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AutoFollow_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox urlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button autoFollowbtn;
    }
}