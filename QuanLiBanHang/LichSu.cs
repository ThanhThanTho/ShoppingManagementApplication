using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.MinDate = new DateTime(1990, 1, 1);
            dateTimePicker1.Value = dateTimePicker1.MinDate;
            loadData();
        }

        private void loadData()
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                comboBox1.Items.Add("All");
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
            MyOrderContext context = new MyOrderContext();
            if (comboBox1.Text.Equals("All"))
            {
                textBox2.Text = "";
                var data = context.TblChiTietHds.ToList().
                    Select(item => new
                    {
                        MaHoaDon = item.MaHd,
                        TenHang = tenMH(item),
                        SoLuong = item.SoLuong,
                        MaHang = item.MaHang,
                        MaChiTiet = item.MaChiTietHd,
                        NgayDat = NgayDat(item).Day + "/" + NgayDat(item).Month + "/" + NgayDat(item).Year
                    }).ToList();
                dataGridView1.DataSource = data;
            }
            else
            {
                textBox2.Text = "";
                var data = context.TblChiTietHds.ToList().
                    Where(p => p.MaHang.Equals(comboBox1.Text)).ToList().
                    Select(item => new
                    {
                        MaHoaDon = item.MaHd,
                        TenHang = tenMH(item),
                        SoLuong = item.SoLuong,
                        MaHang = item.MaHang,
                        MaChiTiet = item.MaChiTietHd,
                        NgayDat = NgayDat(item).Day + "/" + NgayDat(item).Month + "/" + NgayDat(item).Year
                    }).ToList();
                dataGridView1.DataSource = data;
            }
        }
        private string tenMH(TblChiTietHd item)
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
            MyOrderContext context = new MyOrderContext();
            if (textBox2.Text.Length == 0)
            {
                var data = context.TblChiTietHds.ToList().
                    Select(item => new
                    {
                        MaHoaDon = item.MaHd,
                        TenHang = tenMH(item),
                        SoLuong = item.SoLuong,
                        MaHang = item.MaHang,
                        MaChiTiet = item.MaChiTietHd,
                        NgayDat = NgayDat(item).Day + "/" + NgayDat(item).Month + "/" + NgayDat(item).Year
                    }).ToList();
                dataGridView1.DataSource = data;
            }
            else
            {
                var data = context.TblChiTietHds.ToList().
                        Where(p => tenMH(p).ToLower().Replace(" ", "").
                        Contains(textBox2.Text.ToLower().Replace(" ", ""))).ToList().
                        Select(item => new
                        {
                            MaHoaDon = item.MaHd,
                            TenHang = tenMH(item),
                            SoLuong = item.SoLuong,
                            MaHang = item.MaHang,
                            MaChiTiet = item.MaChiTietHd,
                            NgayDat = NgayDat(item).Day + "/" + NgayDat(item).Month + "/" + NgayDat(item).Year
                        }).ToList();
                dataGridView1.DataSource = data;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "All";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
            }
            else
            {
                MyOrderContext context = new MyOrderContext();
                var data = context.TblChiTietHds.ToList().
                    Where(p => NgayDat(p) >= dateTimePicker1.Value &&
                    NgayDat(p) < dateTimePicker2.Value).ToList().
                    Select(item => new
                    {
                        MaHoaDon = item.MaHd,
                        TenHang = tenMH(item),
                        SoLuong = item.SoLuong,
                        MaHang = item.MaHang,
                        MaChiTiet = item.MaChiTietHd,
                        NgayDat = NgayDat(item).Day + "/" + NgayDat(item).Month + "/" + NgayDat(item).Year
                    }).ToList();
                dataGridView1.DataSource = data;
            }
        }

        public DateTime NgayDat(TblChiTietHd a)
        {
            MyOrderContext context = new MyOrderContext();
            var data = context.TblHoadons.ToList().
                Where(p => p.MaHd == a.MaHd).ToList();
            return data[0].NgayHd;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
            }
            else
            {
                MyOrderContext context = new MyOrderContext();
                var data = context.TblChiTietHds.ToList().
                    Where(p => NgayDat(p) >= dateTimePicker1.Value &&
                    NgayDat(p) < dateTimePicker2.Value).ToList().
                    Select(item => new
                    {
                        MaHoaDon = item.MaHd,
                        TenHang = tenMH(item),
                        SoLuong = item.SoLuong,
                        MaHang = item.MaHang,
                        MaChiTiet = item.MaChiTietHd,
                        NgayDat = NgayDat(item).Day + "/" + NgayDat(item).Month + "/" + NgayDat(item).Year
                    }).ToList();
                dataGridView1.DataSource = data;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn in báo cáo?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveFileDialog a = new SaveFileDialog();
                a.Filter = "Data Files (*.dat|(*.txt)";
                a.DefaultExt = "dat";
                a.FileName = "dat";
                if (a.ShowDialog() == DialogResult.OK)
                {
                    string path = a.FileName;
                    StreamWriter writer = new StreamWriter(path);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                        {
                            writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                        }
                        writer.WriteLine("");
                        writer.WriteLine("----------------------------------------------------------");
                    }
                    writer.Close();
                    MessageBox.Show("In báo cáo thành công");
                }
                else
                {
                    MessageBox.Show("Đã hủy in báo cáo");
                }
            }
        }
    }
}
