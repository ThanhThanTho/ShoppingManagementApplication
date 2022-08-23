using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanHang
{
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = Color.LightBlue;
            label2.BackColor = this.BackColor;
            label3.BackColor = this.BackColor;
            label4.BackColor = this.BackColor;
            button1.BackColor = Color.Orange;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = this.BackColor;
            label2.BackColor = this.BackColor;
            label3.BackColor = this.BackColor;
            label4.BackColor = this.BackColor;
            button1.BackColor = Color.Orange;
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"..\..\..\Picture\QuanLyBG.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            button1.BackColor = Color.Orange;
        }

        private void QuanLy_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = this.BackColor;
            label2.BackColor = this.BackColor;
            label3.BackColor = this.BackColor;
            label4.BackColor = this.BackColor;
            button1.BackColor = Color.Orange;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.BackColor = Color.LightBlue;
            label1.BackColor = this.BackColor;
            label3.BackColor = this.BackColor;
            label4.BackColor = this.BackColor;
            button1.BackColor = Color.Orange;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = Color.LightBlue;
            label2.BackColor = this.BackColor;
            label1.BackColor = this.BackColor;
            label4.BackColor = this.BackColor;
            button1.BackColor = Color.Orange;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.BackColor = Color.LightBlue;
            label2.BackColor = this.BackColor;
            label3.BackColor = this.BackColor;
            label1.BackColor = this.BackColor;
            button1.BackColor = Color.Orange;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.BackColor = this.BackColor;
            label2.BackColor = this.BackColor;
            label3.BackColor = this.BackColor;
            label4.BackColor = this.BackColor;
            button1.BackColor = Color.Orange;
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                DangNhap a = new DangNhap();
                a.ShowDialog();
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhachHang a = new KhachHang();
            a.ShowDialog();
            this.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MatHang a = new MatHang();
            a.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DatHang a = new DatHang();
            a.ShowDialog();
            this.Close();
        }
    }
}
