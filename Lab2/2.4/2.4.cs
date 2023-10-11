using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Random random = new Random();
            int x = random.Next(0, this.Width);
            int y = random.Next(0, this.Height);

            Font drawFont = new Font("Arial", 12);
            Brush drawBrush = new SolidBrush(Color.Black);

            Graphics g = e.Graphics;
            g.DrawString("Paint Event", drawFont, drawBrush, x, y);
        }
    }
}
