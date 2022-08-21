using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiBanHang.Models;

namespace QuanLiBanHang
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(@"..\..\..\Picture\DangNhap.jpg");
            this.BackgroundImage = myimage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                textBox2.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 | textBox2.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên người dùng hoặc mật khẩu");
            }
            else
            {
                logIn();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox1.Text.Length == 0 | textBox2.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập tên người dùng hoặc mật khẩu");
                }
                else
                {
                    logIn();
                }
            }
        }

        public void logIn()
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                foreach (TblUser user in context.TblUsers)
                {
                    if (user.Username.Equals(textBox1.Text) && user.Pass.ToString().Equals(textBox2.Text))
                    {
                        MessageBox.Show("Đăng nhập thành công. Chào mừng bạn đến với chương trình.");
                        this.Hide();
                        QuanLy a = new QuanLy();
                        a.ShowDialog();
                        this.Close();
                    }
                }
                MessageBox.Show("Bạn nhập sai tên truy cập hoặc mật khẩu. Vui lòng kiểm tra lại.");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox1.Text.Length==0)
                {
                    MessageBox.Show("Hãy nhập tên người dùng");
                    textBox1.Focus();
                }
                else if (textBox2.Text.Length==0)
                {
                    textBox2.Focus();
                }
                else if (textBox2.Text.Length != 0)
                {
                    logIn();
                }
            }
        }
    }
}
