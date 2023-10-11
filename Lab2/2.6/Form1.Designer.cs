namespace _2._6
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
            this.NameTxT = new System.Windows.Forms.TextBox();
            this.ClassTxT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BirthDay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataSinhVien = new System.Windows.Forms.DataGridView();
            this.namButton = new System.Windows.Forms.RadioButton();
            this.nuButton = new System.Windows.Forms.RadioButton();
            this.IDTxT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // NameTxT
            // 
            this.NameTxT.Location = new System.Drawing.Point(102, 55);
            this.NameTxT.Name = "NameTxT";
            this.NameTxT.Size = new System.Drawing.Size(213, 22);
            this.NameTxT.TabIndex = 2;
            // 
            // ClassTxT
            // 
            this.ClassTxT.Location = new System.Drawing.Point(102, 94);
            this.ClassTxT.Name = "ClassTxT";
            this.ClassTxT.Size = new System.Drawing.Size(213, 22);
            this.ClassTxT.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Class";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Gender";
            // 
            // BirthDay
            // 
            this.BirthDay.Location = new System.Drawing.Point(429, 55);
            this.BirthDay.Name = "BirthDay";
            this.BirthDay.Size = new System.Drawing.Size(200, 22);
            this.BirthDay.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Birthday";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(461, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 35);
            this.button2.TabIndex = 10;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(548, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 35);
            this.button3.TabIndex = 11;
            this.button3.Text = "Edit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataSinhVien
            // 
            this.dataSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSinhVien.Location = new System.Drawing.Point(41, 184);
            this.dataSinhVien.Name = "dataSinhVien";
            this.dataSinhVien.RowHeadersWidth = 51;
            this.dataSinhVien.RowTemplate.Height = 24;
            this.dataSinhVien.Size = new System.Drawing.Size(734, 244);
            this.dataSinhVien.TabIndex = 12;
            // 
            // namButton
            // 
            this.namButton.AutoSize = true;
            this.namButton.Checked = true;
            this.namButton.Location = new System.Drawing.Point(126, 131);
            this.namButton.Name = "namButton";
            this.namButton.Size = new System.Drawing.Size(57, 20);
            this.namButton.TabIndex = 13;
            this.namButton.TabStop = true;
            this.namButton.Text = "Nam";
            this.namButton.UseVisualStyleBackColor = true;
            // 
            // nuButton
            // 
            this.nuButton.AutoSize = true;
            this.nuButton.Location = new System.Drawing.Point(189, 131);
            this.nuButton.Name = "nuButton";
            this.nuButton.Size = new System.Drawing.Size(45, 20);
            this.nuButton.TabIndex = 14;
            this.nuButton.Text = "Nu";
            this.nuButton.UseVisualStyleBackColor = true;
            // 
            // IDTxT
            // 
            this.IDTxT.Enabled = false;
            this.IDTxT.Location = new System.Drawing.Point(102, 19);
            this.IDTxT.Name = "IDTxT";
            this.IDTxT.Size = new System.Drawing.Size(213, 22);
            this.IDTxT.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IDTxT);
            this.Controls.Add(this.nuButton);
            this.Controls.Add(this.namButton);
            this.Controls.Add(this.dataSinhVien);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BirthDay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClassTxT);
            this.Controls.Add(this.NameTxT);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataSinhVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox NameTxT;
        private System.Windows.Forms.TextBox ClassTxT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker BirthDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataSinhVien;
        private System.Windows.Forms.RadioButton namButton;
        private System.Windows.Forms.RadioButton nuButton;
        private System.Windows.Forms.TextBox IDTxT;
        private System.Windows.Forms.Label label5;
    }
}

