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
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = this.BackColor;
            label2.BackColor = this.BackColor;
            label3.BackColor = this.BackColor;
            label4.BackColor = this.BackColor;
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"..\..\..\Picture\QuanLyBG.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            button1.BackColor = this.BackColor;
        }

        private void QuanLy_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = this.BackColor;
            label2.BackColor = this.BackColor;
            label3.BackColor = this.BackColor;
            label4.BackColor = this.BackColor;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.BackColor = Color.LightBlue;
            label1.BackColor = this.BackColor;
            label3.BackColor = this.BackColor;
            label4.BackColor = this.BackColor;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = Color.LightBlue;
            label2.BackColor = this.BackColor;
            label1.BackColor = this.BackColor;
            label4.BackColor = this.BackColor;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.BackColor = Color.LightBlue;
            label2.BackColor = this.BackColor;
            label3.BackColor = this.BackColor;
            label1.BackColor = this.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.BackColor = this.BackColor;
            label2.BackColor = this.BackColor;
            label3.BackColor = this.BackColor;
            label4.BackColor = this.BackColor;
            if (MessageBox.Show("Bạn có chắc muốn trở về màn hình đăng nhập?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                DangNhap a = new DangNhap();
                a.ShowDialog();
                this.Close();
            }
        }
    }
}
