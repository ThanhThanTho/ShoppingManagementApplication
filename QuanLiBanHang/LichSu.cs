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
    public partial class LichSu : Form
    {
        public LichSu()
        {
            InitializeComponent();
        }

        private void LichSu_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                this.BackColor = Color.DarkOrange;
                var data = context.TblMatHangs.ToList();
                foreach (TblMatHang item in data)
                {
                    comboBox1.Items.Add(item.MaHang);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn trở về?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                QuanLy a = new QuanLy();
                a.ShowDialog();
                this.Close();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            using (MyOrderContext context = new MyOrderContext())
            {
                var data = context.TblChiTietHds.ToList().
                    Where(p => p.MaHang.Equals(comboBox1.Text)).ToList().
                    Select(item => new
                    {
                        MaHoaDon = item.MaHd,
                        TenHang = tenMH(item),
                        SoLuong = item.SoLuong,
                        MaHang = item.MaHang,
                        MaChiTiet = item.MaChiTietHd
                    }).ToList();
                dataGridView1.DataSource = data;
                for (int i = 0; i < context.TblChiTietHds.ToList().Count; i++)
                {
                    if (context.TblChiTietHds.ToList()[i].MaHang.Equals(comboBox1.Text))
                    {
                        context.TblChiTietHds.Remove(context.TblChiTietHds.ToList()[i]);
                    }
                }
                comboBox1.Items.Clear();
                loadData();
                for (int i = 0; i < context.TblHoadons.ToList().Count; i++)
                {
                    if (!coChiTiet(Convert.ToInt32(context.TblHoadons.ToList()[i].MaHd)))
                    {
                        context.TblHoadons.Remove(context.TblHoadons.ToList()[i]);
                    }
                }
                context.SaveChanges();
            }
        }

        private object tenMH(TblChiTietHd item)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                var MatHang = context.TblMatHangs.ToList();
                foreach (TblMatHang mathang in MatHang)
                {
                    if (mathang.MaHang.Equals(item.MaHang))
                    {
                        return mathang.TenHang;
                    }
                }
            }
            return null;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            MyOrderContext context = new MyOrderContext();
            var data = context.TblChiTietHds.ToList().
                    Where(p => tenMH(p).Equals(textBox2.Text)).ToList().
                    Select(item => new
                    {
                        MaHoaDon = item.MaHd,
                        TenHang = tenMH(item),
                        SoLuong = item.SoLuong,
                        MaHang = item.MaHang,
                        MaChiTiet = item.MaChiTietHd
                    }).ToList();
            dataGridView1.DataSource = data;
            string maMH = "";
            foreach (TblMatHang item in context.TblMatHangs.ToList())
            {
                if (item.TenHang.Equals(textBox2.Text))
                {
                    maMH = item.MaHang;
                    break;
                }
            }
            for (int i = 0; i < context.TblChiTietHds.ToList().Count; i++)
            {
                if (context.TblChiTietHds.ToList()[i].MaHang.Equals(maMH))
                {
                    
                    context.TblChiTietHds.Remove(context.TblChiTietHds.ToList()[i]);
                }
            }
            comboBox1.Items.Clear();
            loadData();
            for (int i = 0; i < context.TblHoadons.ToList().Count; i++)
            {
                if (!coChiTiet(Convert.ToInt32(context.TblHoadons.ToList()[i].MaHd)))
                {
                    context.TblHoadons.Remove(context.TblHoadons.ToList()[i]);
                }
            }
            context.SaveChanges();
        }

        public bool coChiTiet(int maHD)
        {
            MyOrderContext context = new MyOrderContext();
            List<int> list = new List<int>();
            foreach (TblHoadon item in context.TblHoadons)
            {
                list.Add(Convert.ToInt32(item.MaHd));
            }
            foreach (TblChiTietHd item in context.TblChiTietHds.ToList())
            {
                if (item.MaHd==maHD)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
