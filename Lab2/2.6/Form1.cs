using _2._6.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._6
{
    public partial class Form1 : Form
    {
        QuanLiSinhVienEntities context= new QuanLiSinhVienEntities();
        public Form1()
        {
            InitializeComponent();
            LoadData();
            AddBinding();
        }
        #region methods
        void RemoveBinding()
        {
            NameTxT.DataBindings.Remove(NameTxT.DataBindings["Text"]);
            ClassTxT.DataBindings.Remove(ClassTxT.DataBindings["Text"]);
            BirthDay.DataBindings.Remove(BirthDay.DataBindings["Text"]);
            IDTxT.DataBindings.Remove(IDTxT.DataBindings["Text"]);
        }
        void AddBinding()
        {
            
            NameTxT.DataBindings.Add("Text", dataSinhVien.DataSource, "Name");
            ClassTxT.DataBindings.Add("Text", dataSinhVien.DataSource, "Class");
            BirthDay.DataBindings.Add("Text", dataSinhVien.DataSource, "BirthDay");
            IDTxT.DataBindings.Add("Text", dataSinhVien.DataSource, "ID");
        }
        void LoadData()
        {
            var result = from c in context.SinhVien select new { ID = c.ID, Name = c.DisplayName, Class = c.Lop.DisplayName, Gender = c.Gender == true ? "Nam" : "Nu", BirthDay = c.BirthDay };
            dataSinhVien.DataSource = result.ToList();
        }
        #endregion
    

        private void button1_Click(object sender, EventArgs e)
        {
            // add button
            int? idLop = null;
            if((from c in context.Lop where c.DisplayName == ClassTxT.Text select c).ToList().Count() == 0)
            {
                context.Lop.Add(new Lop { DisplayName = ClassTxT.Text });
                context.SaveChanges();
                
            }
            Lop lop = context.Lop.Where(p=> p.DisplayName == ClassTxT.Text).FirstOrDefault();
            idLop = lop.ID;

            SinhVien sv = new SinhVien() { DisplayName = NameTxT.Text, BirthDay= BirthDay.Value,  IDLop = idLop, Gender= namButton.Checked,ID=100};
            context.SinhVien.Add(sv);
            context.SaveChanges();
            LoadData();
            RemoveBinding();
            AddBinding();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete button
            SinhVien sv = context.SinhVien.Find(int.Parse(IDTxT.Text));
            if (sv != null)
            {
                context.SinhVien.Remove(sv);
                context.SaveChanges();
                LoadData();
                RemoveBinding();
                AddBinding();
            }
            else
            {
                MessageBox.Show("Khong ton tai ID sinh vien");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //edit button
            SinhVien sv = context.SinhVien.Find(int.Parse(IDTxT.Text));
            sv.DisplayName = NameTxT.Text;
            int? idLop = null;
            Lop lop = context.Lop.Where(p => p.DisplayName == ClassTxT.Text).FirstOrDefault();
            cv xidLop = lop.ID;
            sv.IDLop = idLop;
            sv.BirthDay = BirthDay.Value;
            sv.Gender = namButton.Checked;
            context.SaveChanges();
            LoadData();
            RemoveBinding();
            AddBinding();
        }
    }
}
