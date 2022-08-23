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
    public partial class DatHang : Form
    {
        public DatHang()
        {
            InitializeComponent();
        }

        private void DatHang_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkOrange;
            buttonDatMua.Enabled = false;
            buttonLtR.Enabled = false;
            buttonRtL.Enabled = false;
            loadData();
        }

        private void loadData()
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                var data1 = context.TblMatHangs.ToList();
                comboBox1.DataSource = data1;
                comboBox1.DisplayMember = "TenHang";
                comboBox1.ValueMember = "MaHang";

                textBoxGia.Text = data1[0].Gia.ToString();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                var data = context.TblMatHangs.ToList();
                foreach (TblMatHang item in data)
                {
                    if (item.MaHang.Equals(comboBox1.SelectedValue))
                    {
                        textBoxGia.Text = item.Gia.ToString();
                    }
                }
            }
        }

        private void buttonTaoMoi_Click(object sender, EventArgs e)
        {
            textBoxMaHD.Text = "";
            textBoxDiaChi.Text = "";
            textBoxTenKH.Text = "";
            textBoxNgayDat.Text = "";
            textBoxMaKH.Text = "";
            textBoxSoLuong.Text = "";
        }

        private void buttonTroVe_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn trở về?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                QuanLy a = new QuanLy();
                a.ShowDialog();
                this.Close();
            }
        }

        private void textBoxMaKH_TextChanged(object sender, EventArgs e)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                var dataKH = context.TblKhachHangs.ToList().
                    Where(p => p.MaKh.Equals(textBoxMaKH.Text));
                if (dataKH.ToList().Count!=0)
                {
                    textBoxTenKH.Text = dataKH.ToList()[0].TenKh;
                    textBoxDiaChi.Text = dataKH.ToList()[0].DiaChi;
                }
                else
                {
                    textBoxDiaChi.Text = "";
                    textBoxTenKH.Text = "";
                }
                
            }
        }
    }
}
