using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                e.Graphics.DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            using (Pen pen = new Pen(Color.White, 2))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            //int radius = 20;
            //int borderSize = 2;
            //Panel panel = (Panel)sender;
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            //e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            //int diameter = radius * 2;
            //Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);
            //path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            //path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            //path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            //path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            //path.CloseFigure();
            //panel.Region = new Region(path);
            //using (Pen pen = new Pen(Color.White, borderSize))
            //{
            //    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            //    e.Graphics.DrawPath(pen, path);
            //}
        }
        private void ShowControl3(UserControl ucakBiletiControl)
        {
            panel4.Controls.Clear();

            panel4.Controls.Add(ucakBiletiControl);
        }
        private void ShowControl4(UserControl otobusBiletiControl)
        {
            panel4.Controls.Clear();

            panel4.Controls.Add(otobusBiletiControl);
        }
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            ShowControl3(new UcakBileti());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowControl3(new UcakBileti());
            button3.BackColor = Color.DarkGray;
            button2.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowControl3(new OtobusBileti());
            button3.BackColor = Color.White;
            button2.BackColor = Color.DarkGray;
        }
    }
}
