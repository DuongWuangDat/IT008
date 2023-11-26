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
            this.button2 = new System.Windows.Forms.Button();
            this.autotimbtn = new System.Windows.Forms.Button();
            this.autocmtbtn = new System.Windows.Forms.Button();
            this.urlbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.autofollowbtn = new System.Windows.Forms.Button();
            this.crawlimagebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Location = new System.Drawing.Point(88, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "Log in";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // username_box
            // 
            this.username_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_box.Location = new System.Drawing.Point(222, 38);
            this.username_box.Name = "username_box";
            this.username_box.Size = new System.Drawing.Size(268, 30);
            this.username_box.TabIndex = 1;
            this.username_box.TextChanged += new System.EventHandler(this.username_box_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // password_box
            // 
            this.password_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_box.Location = new System.Drawing.Point(222, 94);
            this.password_box.Name = "password_box";
            this.password_box.Size = new System.Drawing.Size(268, 30);
            this.password_box.TabIndex = 3;
            this.password_box.TextChanged += new System.EventHandler(this.password_box_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.Location = new System.Drawing.Point(412, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(254, 61);
            this.button2.TabIndex = 5;
            this.button2.Text = "Open";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // autotimbtn
            // 
            this.autotimbtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.autotimbtn.Location = new System.Drawing.Point(88, 284);
            this.autotimbtn.Name = "autotimbtn";
            this.autotimbtn.Size = new System.Drawing.Size(254, 61);
            this.autotimbtn.TabIndex = 6;
            this.autotimbtn.Text = "AutoTim";
            this.autotimbtn.UseVisualStyleBackColor = false;
            this.autotimbtn.Click += new System.EventHandler(this.autotimbtn_Click);
            // 
            // autocmtbtn
            // 
            this.autocmtbtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.autocmtbtn.Location = new System.Drawing.Point(412, 284);
            this.autocmtbtn.Name = "autocmtbtn";
            this.autocmtbtn.Size = new System.Drawing.Size(254, 61);
            this.autocmtbtn.TabIndex = 7;
            this.autocmtbtn.Text = "AutoComment";
            this.autocmtbtn.UseVisualStyleBackColor = false;
            // 
            // urlbox
            // 
            this.urlbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlbox.Location = new System.Drawing.Point(222, 148);
            this.urlbox.Name = "urlbox";
            this.urlbox.Size = new System.Drawing.Size(268, 30);
            this.urlbox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Url";
            // 
            // autofollowbtn
            // 
            this.autofollowbtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.autofollowbtn.Location = new System.Drawing.Point(88, 375);
            this.autofollowbtn.Name = "autofollowbtn";
            this.autofollowbtn.Size = new System.Drawing.Size(254, 61);
            this.autofollowbtn.TabIndex = 10;
            this.autofollowbtn.Text = "AutoFollow";
            this.autofollowbtn.UseVisualStyleBackColor = false;
            this.autofollowbtn.Click += new System.EventHandler(this.autofollowbtn_Click);
            // 
            // crawlimagebtn
            // 
            this.crawlimagebtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.crawlimagebtn.Location = new System.Drawing.Point(412, 375);
            this.crawlimagebtn.Name = "crawlimagebtn";
            this.crawlimagebtn.Size = new System.Drawing.Size(254, 61);
            this.crawlimagebtn.TabIndex = 11;
            this.crawlimagebtn.Text = "Crawl Image";
            this.crawlimagebtn.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.crawlimagebtn);
            this.Controls.Add(this.autofollowbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.urlbox);
            this.Controls.Add(this.autocmtbtn);
            this.Controls.Add(this.autotimbtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.username_box);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox username_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button autotimbtn;
        private System.Windows.Forms.Button autocmtbtn;
        private System.Windows.Forms.TextBox urlbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button autofollowbtn;
        private System.Windows.Forms.Button crawlimagebtn;
    }
}

