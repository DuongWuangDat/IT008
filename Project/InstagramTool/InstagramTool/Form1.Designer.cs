namespace InstagramTool
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.username_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.password_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.autotimbtn = new System.Windows.Forms.Button();
            this.autocmtbtn = new System.Windows.Forms.Button();
            this.urlbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.autofollowbtn = new System.Windows.Forms.Button();
            this.CrawlImage_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.user_RichTb = new System.Windows.Forms.RichTextBox();
            this.comment_RichTb = new System.Windows.Forms.RichTextBox();
            this.userfile = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.toollabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Location = new System.Drawing.Point(29, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "Log in";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // username_box
            // 
            this.username_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_box.Location = new System.Drawing.Point(142, 85);
            this.username_box.Name = "username_box";
            this.username_box.Size = new System.Drawing.Size(268, 30);
            this.username_box.TabIndex = 1;
            this.username_box.TextChanged += new System.EventHandler(this.username_box_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // password_box
            // 
            this.password_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_box.Location = new System.Drawing.Point(564, 85);
            this.password_box.Name = "password_box";
            this.password_box.PasswordChar = '*';
            this.password_box.Size = new System.Drawing.Size(260, 30);
            this.password_box.TabIndex = 3;
            this.password_box.TextChanged += new System.EventHandler(this.password_box_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(460, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // autotimbtn
            // 
            this.autotimbtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.autotimbtn.Location = new System.Drawing.Point(29, 278);
            this.autotimbtn.Name = "autotimbtn";
            this.autotimbtn.Size = new System.Drawing.Size(183, 61);
            this.autotimbtn.TabIndex = 6;
            this.autotimbtn.Text = "AutoTim";
            this.autotimbtn.UseVisualStyleBackColor = false;
            this.autotimbtn.Click += new System.EventHandler(this.autotimbtn_Click);
            // 
            // autocmtbtn
            // 
            this.autocmtbtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.autocmtbtn.Location = new System.Drawing.Point(29, 362);
            this.autocmtbtn.Name = "autocmtbtn";
            this.autocmtbtn.Size = new System.Drawing.Size(183, 61);
            this.autocmtbtn.TabIndex = 7;
            this.autocmtbtn.Text = "AutoComment";
            this.autocmtbtn.UseVisualStyleBackColor = false;
            this.autocmtbtn.Click += new System.EventHandler(this.autocmtbtn_Click);
            // 
            // urlbox
            // 
            this.urlbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlbox.Location = new System.Drawing.Point(557, 12);
            this.urlbox.Name = "urlbox";
            this.urlbox.Size = new System.Drawing.Size(268, 30);
            this.urlbox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(486, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Url";
            // 
            // autofollowbtn
            // 
            this.autofollowbtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.autofollowbtn.Location = new System.Drawing.Point(29, 444);
            this.autofollowbtn.Name = "autofollowbtn";
            this.autofollowbtn.Size = new System.Drawing.Size(183, 61);
            this.autofollowbtn.TabIndex = 10;
            this.autofollowbtn.Text = "AutoFollow";
            this.autofollowbtn.UseVisualStyleBackColor = false;
            this.autofollowbtn.Click += new System.EventHandler(this.autofollowbtn_Click);
            // 
            // CrawlImage_btn
            // 
            this.CrawlImage_btn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CrawlImage_btn.Location = new System.Drawing.Point(29, 527);
            this.CrawlImage_btn.Name = "CrawlImage_btn";
            this.CrawlImage_btn.Size = new System.Drawing.Size(183, 61);
            this.CrawlImage_btn.TabIndex = 11;
            this.CrawlImage_btn.Text = "Crawl Image";
            this.CrawlImage_btn.UseVisualStyleBackColor = false;
            this.CrawlImage_btn.Click += new System.EventHandler(this.CrawlImage_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.DeepPink;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(368, 46);
            this.label4.TabIndex = 12;
            this.label4.Text = "Instagram AutoTool";
            // 
            // user_RichTb
            // 
            this.user_RichTb.Location = new System.Drawing.Point(245, 147);
            this.user_RichTb.Name = "user_RichTb";
            this.user_RichTb.Size = new System.Drawing.Size(579, 215);
            this.user_RichTb.TabIndex = 13;
            this.user_RichTb.Text = "";
            // 
            // comment_RichTb
            // 
            this.comment_RichTb.Location = new System.Drawing.Point(245, 373);
            this.comment_RichTb.Name = "comment_RichTb";
            this.comment_RichTb.Size = new System.Drawing.Size(579, 215);
            this.comment_RichTb.TabIndex = 14;
            this.comment_RichTb.Text = "";
            // 
            // userfile
            // 
            this.userfile.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.userfile.Location = new System.Drawing.Point(849, 224);
            this.userfile.Name = "userfile";
            this.userfile.Size = new System.Drawing.Size(121, 61);
            this.userfile.TabIndex = 15;
            this.userfile.Text = "Add user \r\n.txt file";
            this.userfile.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.Location = new System.Drawing.Point(849, 444);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 61);
            this.button3.TabIndex = 16;
            this.button3.Text = "Add comment\r\n.txt file";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // toollabel
            // 
            this.toollabel.AutoSize = true;
            this.toollabel.Location = new System.Drawing.Point(26, 12);
            this.toollabel.Name = "toollabel";
            this.toollabel.Size = new System.Drawing.Size(35, 16);
            this.toollabel.TabIndex = 17;
            this.toollabel.Text = "Tool";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(70, 7);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.toollabel);
            this.panel1.Location = new System.Drawing.Point(0, 617);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 93);
            this.panel1.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 654);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.userfile);
            this.Controls.Add(this.comment_RichTb);
            this.Controls.Add(this.user_RichTb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CrawlImage_btn);
            this.Controls.Add(this.autofollowbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.urlbox);
            this.Controls.Add(this.autocmtbtn);
            this.Controls.Add(this.autotimbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.username_box);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox username_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button autotimbtn;
        private System.Windows.Forms.Button autocmtbtn;
        private System.Windows.Forms.TextBox urlbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button autofollowbtn;
        private System.Windows.Forms.Button CrawlImage_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox user_RichTb;
        private System.Windows.Forms.RichTextBox comment_RichTb;
        private System.Windows.Forms.Button userfile;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label toollabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
    }
}

