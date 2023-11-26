namespace InstagramTool
{
    partial class Form2
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
            this.griduser = new System.Windows.Forms.DataGridView();
            this.userbox = new System.Windows.Forms.TextBox();
            this.urluser = new System.Windows.Forms.Label();
            this.gridcmt = new System.Windows.Forms.DataGridView();
            this.cmt = new System.Windows.Forms.Label();
            this.cmtbox = new System.Windows.Forms.TextBox();
            this.adduser = new System.Windows.Forms.Button();
            this.addcmt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.griduser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcmt)).BeginInit();
            this.SuspendLayout();
            // 
            // griduser
            // 
            this.griduser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.griduser.Location = new System.Drawing.Point(120, 145);
            this.griduser.Name = "griduser";
            this.griduser.RowHeadersWidth = 51;
            this.griduser.RowTemplate.Height = 24;
            this.griduser.Size = new System.Drawing.Size(528, 171);
            this.griduser.TabIndex = 0;
            // 
            // userbox
            // 
            this.userbox.Location = new System.Drawing.Point(248, 26);
            this.userbox.Name = "userbox";
            this.userbox.Size = new System.Drawing.Size(216, 22);
            this.userbox.TabIndex = 1;
            // 
            // urluser
            // 
            this.urluser.AutoSize = true;
            this.urluser.Location = new System.Drawing.Point(161, 32);
            this.urluser.Name = "urluser";
            this.urluser.Size = new System.Drawing.Size(53, 16);
            this.urluser.TabIndex = 2;
            this.urluser.Text = "Url user";
            // 
            // gridcmt
            // 
            this.gridcmt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridcmt.Location = new System.Drawing.Point(120, 371);
            this.gridcmt.Name = "gridcmt";
            this.gridcmt.RowHeadersWidth = 51;
            this.gridcmt.RowTemplate.Height = 24;
            this.gridcmt.Size = new System.Drawing.Size(528, 171);
            this.gridcmt.TabIndex = 3;
            // 
            // cmt
            // 
            this.cmt.AutoSize = true;
            this.cmt.Location = new System.Drawing.Point(161, 70);
            this.cmt.Name = "cmt";
            this.cmt.Size = new System.Drawing.Size(64, 16);
            this.cmt.TabIndex = 4;
            this.cmt.Text = "Comment";
            // 
            // cmtbox
            // 
            this.cmtbox.Location = new System.Drawing.Point(248, 64);
            this.cmtbox.Name = "cmtbox";
            this.cmtbox.Size = new System.Drawing.Size(216, 22);
            this.cmtbox.TabIndex = 5;
            // 
            // adduser
            // 
            this.adduser.Location = new System.Drawing.Point(496, 25);
            this.adduser.Name = "adduser";
            this.adduser.Size = new System.Drawing.Size(102, 23);
            this.adduser.TabIndex = 6;
            this.adduser.Text = "Add user";
            this.adduser.UseVisualStyleBackColor = true;
            this.adduser.Click += new System.EventHandler(this.adduser_Click);
            // 
            // addcmt
            // 
            this.addcmt.Location = new System.Drawing.Point(496, 70);
            this.addcmt.Name = "addcmt";
            this.addcmt.Size = new System.Drawing.Size(102, 23);
            this.addcmt.TabIndex = 7;
            this.addcmt.Text = "Add comment";
            this.addcmt.UseVisualStyleBackColor = true;
            this.addcmt.Click += new System.EventHandler(this.addcmt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "List user";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "List comment";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addcmt);
            this.Controls.Add(this.adduser);
            this.Controls.Add(this.cmtbox);
            this.Controls.Add(this.cmt);
            this.Controls.Add(this.gridcmt);
            this.Controls.Add(this.urluser);
            this.Controls.Add(this.userbox);
            this.Controls.Add(this.griduser);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.griduser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridcmt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView griduser;
        private System.Windows.Forms.TextBox userbox;
        private System.Windows.Forms.Label urluser;
        private System.Windows.Forms.DataGridView gridcmt;
        private System.Windows.Forms.Label cmt;
        private System.Windows.Forms.TextBox cmtbox;
        private System.Windows.Forms.Button adduser;
        private System.Windows.Forms.Button addcmt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}