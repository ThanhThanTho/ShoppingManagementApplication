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

            loadData();
        }

        private void loadData()
        {
            this.BackColor = Color.DarkOrange;
            buttonDatMua.Enabled = false;
            buttonLtR.Enabled = false;
            buttonRtL.Enabled = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                if (dataKH.ToList().Count != 0)
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

        private void textBoxMaHD_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMaHD.Text.Length == 0)
            {
                buttonDatMua.Enabled = false;
                dataGridView1.DataSource = null;
                buttonLtR.Enabled = false;
                buttonRtL.Enabled = false;
                textBoxNgayDat.Text = "";
                textBoxDiaChi.Text = "";
                textBoxTenKH.Text = "";
                textBoxMaKH.Text = "";
                textBox1.Text = "";
                comboBox2.DataSource = null;
                comboBox2.Items.Clear();
            }
            else
            {
                using (MyOrderContext context = new MyOrderContext())
                {
                    var dataHD = context.TblHoadons.ToList().
                        Where(p => p.MaHd.ToString().Equals(textBoxMaHD.Text)).ToList();
                    if (dataHD.Count != 0)
                    {
                        var dataKH = context.TblKhachHangs.ToList().
                        Where(p => p.MaKh.Equals(layMaKH(Convert.ToInt32(textBoxMaHD.Text)))).ToList();
                        buttonLtR.Enabled = true;
                        buttonRtL.Enabled = true;
                        buttonDatMua.Enabled = false;
                        textBoxNgayDat.Text =
                            dataHD[0].NgayHd.Day + "/" + dataHD[0].NgayHd.Month + "/" + dataHD[0].NgayHd.Year;
                        textBoxMaKH.Text = dataKH[0].MaKh;
                        textBoxTenKH.Text = dataKH[0].TenKh;
                        textBoxDiaChi.Text = dataKH[0].DiaChi;
                        getDetail();
                    }
                    else
                    {
                        textBoxDiaChi.Text = "";
                        textBoxTenKH.Text = "";
                        textBoxMaKH.Text = "";
                        buttonLtR.Enabled = false;
                        buttonRtL.Enabled = false;
                        buttonDatMua.Enabled = true;
                        dataGridView1.DataSource = null;
                        textBoxNgayDat.Text =
                            DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                        textBox1.Text = "";
                    }
                }
            }
        }

        public string layMaKH(int maHD)
        {
            MyOrderContext context = new MyOrderContext();
            var dataHD = context.TblHoadons.ToList().
                Where(p => p.MaHd == Convert.ToDecimal(maHD)).ToList();
            var dataKH = context.TblKhachHangs.ToList().
                Where(p => p.MaKh.Equals(dataHD[0].MaKh)).ToList();
            return dataKH[0].MaKh;
        }

        private void buttonDatMua_EnabledChanged(object sender, EventArgs e)
        {
            if (buttonDatMua.Enabled)
            {
                buttonDatMua.BackColor = Color.White;
            }
            else buttonDatMua.BackColor = Color.Gray;
        }

        private void buttonLtR_EnabledChanged(object sender, EventArgs e)
        {
            if (buttonLtR.Enabled)
            {
                buttonLtR.BackColor = Color.White;
            }
            else buttonLtR.BackColor = Color.Gray;
        }

        private void buttonRtL_EnabledChanged(object sender, EventArgs e)
        {
            if (buttonRtL.Enabled)
            {
                buttonRtL.BackColor = Color.White;
            }
            else buttonRtL.BackColor = Color.Gray;
        }

        private void buttonLtR_Click(object sender, EventArgs e)
        {
            int a;
            if (textBoxSoLuong.Text.Length == 0 | !int.TryParse(textBoxSoLuong.Text, out a))
            {
                MessageBox.Show("Số lượng không hợp lệ, xin hãy nhập lại");
            }
            else
            {
                using (MyOrderContext context = new MyOrderContext())
                {
                    var HoaDon = context.TblHoadons.ToList().
                        Where(p => p.MaHd == Convert.ToDecimal(textBoxMaHD.Text)).ToList();
                    var ChiTiet = context.TblChiTietHds.ToList();
                    TblChiTietHd ChiTietMoi = new TblChiTietHd();
                    ChiTietMoi.MaHang = comboBox1.SelectedValue.ToString();
                    ChiTietMoi.SoLuong = Convert.ToInt32(textBoxSoLuong.Text);
                    if (!exist(ChiTietMoi, HoaDon[0]))
                    {
                        ChiTietMoi.MaHd = HoaDon[0].MaHd;
                        context.TblChiTietHds.Add(ChiTietMoi);
                        context.SaveChanges();
                        getDetail();
                    }
                    else
                    {
                        var CacChiTiet = context.TblChiTietHds.ToList().
                            Where(p => p.MaHd == Convert.ToDecimal(textBoxMaHD.Text)).ToList();
                        foreach (TblChiTietHd item in CacChiTiet)
                        {
                            if (item.MaHang.Equals(comboBox1.SelectedValue))
                            {
                                item.SoLuong += Convert.ToInt32(textBoxSoLuong.Text);
                                break;
                            }
                        }
                        context.SaveChanges();
                        getDetail();
                    }
                }
            }

        }

        public bool exist(TblChiTietHd ct, TblHoadon hd)
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                var ChiTiet = context.TblChiTietHds.ToList().
                    Where(p => p.MaHd == hd.MaHd);
                foreach (TblChiTietHd item in ChiTiet)
                {
                    if (ct.MaHang.Equals(item.MaHang))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void getDetail()
        {
            MyOrderContext context = new MyOrderContext();
            var dataCT = context.TblChiTietHds.ToList().
                            Where(p => p.MaHd.ToString().Equals(textBoxMaHD.Text)).ToList()
                            .Select(item => new
                            {
                                MaHoaDon = item.MaHd,
                                TenHang = tenMH(item),
                                SoLuong = item.SoLuong,
                                MaHang = item.MaHang,
                                MaChiTiet = item.MaChiTietHd
                            }).ToList();
            var dataChiTiet = context.TblChiTietHds.ToList().
            Where(p => p.MaHd.ToString().Equals(textBoxMaHD.Text)).ToList();
            float sum = 0;
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            foreach (TblChiTietHd item in dataChiTiet)
            {
                sum += layGiaTien(item.MaHang) * item.SoLuong;
            }
            if (dataChiTiet.Count != 0)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (TblChiTietHd item in dataChiTiet)
                {
                    dict.Add(tenMH(item), item.MaHang.ToString());
                }
                comboBox2.DataSource = new BindingSource(dict, null);
                comboBox2.DisplayMember = "Key";
                comboBox2.ValueMember = "Value";
            }
            textBox1.Text = sum.ToString("N0");
            dataGridView1.DataSource = dataCT;
        }

        public float layGiaTien(string maHang)
        {
            MyOrderContext context = new MyOrderContext();
            var dataHang = context.TblMatHangs.ToList().
                Where(p => p.MaHang.Equals(maHang)).ToList();
            return dataHang[0].Gia;
        }

        public string tenMH(TblChiTietHd item)
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

        private void buttonRtL_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 mặt hàng để xóa");
            }
            else
            {
                int maCT = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaChiTiet"].Value);
                using (MyOrderContext context = new MyOrderContext())
                {
                    foreach (TblChiTietHd item in context.TblChiTietHds.ToList())
                    {
                        if (item.MaChiTietHd == maCT)
                        {
                            context.TblChiTietHds.Remove(item);
                            context.SaveChanges();
                            break;
                        }
                    }
                    getDetail();
                }
            }
        }

        private void buttonDatMua_Click(object sender, EventArgs e)
        {
            int b;
            if (textBoxMaKH.Text.Length == 0)
            {
                MessageBox.Show("Xin hãy nhập mã khách hàng");
            }
            else if (!int.TryParse(textBoxMaHD.Text, out b))
            {
                MessageBox.Show("Mã hóa đơn phải là 1 số, xin hãy nhập lại.");
            }
            else if (textBoxSoLuong.Text.Length == 0 | !int.TryParse(textBoxSoLuong.Text, out b))
            {
                MessageBox.Show("Số lượng không hợp lệ. Xin hãy nhập lại");
            }
            else
            {
                MyOrderContext context = new MyOrderContext();
                TblHoadon a = new TblHoadon();
                a.MaHd = Convert.ToDecimal(textBoxMaHD.Text);
                a.MaKh = textBoxMaKH.Text;
                string[] date = textBoxNgayDat.Text.Split("/");
                a.NgayHd = new DateTime(Convert.ToInt32(date[2]),
                    Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
                context.TblHoadons.Add(a);
                TblChiTietHd ct = new TblChiTietHd();
                ct.MaHd = Convert.ToDecimal(textBoxMaHD.Text);
                ct.MaHang = comboBox1.SelectedValue.ToString();
                ct.SoLuong = Convert.ToInt32(textBoxSoLuong.Text);
                context.TblChiTietHds.Add(ct);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Thêm đơn thành công");
                    getDetail();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thanh toán?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MyOrderContext context = new MyOrderContext();
                foreach (TblChiTietHd item in context.TblChiTietHds.ToList())
                {
                    if (item.MaHd==Convert.ToDecimal(textBoxMaHD.Text))
                    {
                        context.TblChiTietHds.Remove(item);
                    }
                }
                foreach (TblHoadon item in context.TblHoadons.ToList())
                {
                    if (item.MaHd== Convert.ToDecimal(textBoxMaHD.Text))
                    {
                        context.TblHoadons.Remove(item);
                    }
                }
                context.SaveChanges();
                textBoxMaHD.Text = "";
                textBoxDiaChi.Text = "";
                textBoxTenKH.Text = "";
                textBoxNgayDat.Text = "";
                textBoxMaKH.Text = "";
                textBoxSoLuong.Text = "";
                comboBox2.DataSource = null;
                comboBox2.Items.Clear();
                textBox2.Text = "0";
                textBox1.Text = "0";
                MessageBox.Show("Thanh toán đơn hàng thành công");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thanh toán?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MyOrderContext context = new MyOrderContext();
                List<TblChiTietHd> listCT = new List<TblChiTietHd>();
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    TblChiTietHd a = new TblChiTietHd();
                    a.MaHd = Convert.ToDecimal(item.Cells["MaHoaDon"].Value);
                    a.SoLuong = Convert.ToInt32(item.Cells["SoLuong"].Value);
                    a.MaHang = item.Cells["MaHang"].Value.ToString();
                    listCT.Add(a);
                }
                foreach (TblChiTietHd ct in listCT)
                {
                    foreach (TblChiTietHd item in context.TblChiTietHds.ToList())
                    {
                        if (item.MaHd == ct.MaHd && item.MaHang.Equals(ct.MaHang))
                        {
                            item.SoLuong -= ct.SoLuong;
                            if (item.SoLuong == 0)
                            {
                                context.TblChiTietHds.Remove(item);
                            }
                        }
                    }
                }
                dataGridView2.DataSource = null;
                textBox2.Text = "";
                comboBox2.DataSource = null;
                comboBox2.Items.Clear();
                context.SaveChanges();
                getDetail();
                MessageBox.Show("Thanh toán đơn thành công");
            }
        }

        List<TblChiTietHd> list = new List<TblChiTietHd>();
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            MyOrderContext context = new MyOrderContext();
            var ChiTiet = context.TblChiTietHds.ToList().
                Where(p => p.MaHd.ToString().Equals(textBoxMaHD.Text));
            if (check(comboBox2.SelectedValue.ToString(), list))
            {

                foreach (TblChiTietHd item in list)
                {
                    if (item.MaHang.Equals(comboBox2.SelectedValue))
                    {
                        var gioihan = context.TblChiTietHds.ToList().
                            Where(p => p.MaHd == Convert.ToDecimal(textBoxMaHD.Text) &&
                            p.MaHang.Equals(comboBox2.SelectedValue.ToString())).ToList();
                        int max = gioihan[0].SoLuong;
                        if (numericUpDown1.Value <= max)
                        {
                            item.SoLuong = Convert.ToInt32(numericUpDown1.Value);

                        }
                        else
                        {
                            numericUpDown1.Value = max;
                            item.SoLuong = max;
                            MessageBox.Show("Bạn không thể lấy nhiều hơn số lượng trong hóa đơn. " +
                                "Số lượng hàng mua sẽ được đặt cao nhất");
                        }
                        if (item.SoLuong == 0)
                        {
                            list.Remove(item);
                            break;
                        }
                    }
                }
                var data = list.Select(p => new
                {
                    MaHoaDon = p.MaHd,
                    TenMatHang = tenMH(p),
                    SoLuong = p.SoLuong,
                    MaHang = p.MaHang
                }).ToList();
                dataGridView2.DataSource = data;
                giaTien();
            }
            else
            {
                var gioihan = context.TblChiTietHds.ToList().
                            Where(p => p.MaHd == Convert.ToDecimal(textBoxMaHD.Text) &&
                            p.MaHang.Equals(comboBox2.SelectedValue.ToString())).ToList();
                int max = gioihan[0].SoLuong;
                TblChiTietHd a = new TblChiTietHd();
                a.MaHd = Convert.ToDecimal(textBoxMaHD.Text);
                a.MaHang = comboBox2.SelectedValue.ToString();
                if (numericUpDown1.Value > max)
                {
                    a.SoLuong = max;
                }
                else
                {
                    a.SoLuong = Convert.ToInt32(numericUpDown1.Value);
                }
                list.Add(a);
                var data = list.Select(p => new
                {
                    MaHoaDon = p.MaHd,
                    TenMatHang = tenMH(p),
                    SoLuong = p.SoLuong,
                    MaHang = p.MaHang
                }).ToList();
                dataGridView2.DataSource = data;
                giaTien();
            }
        }

        public bool check(string maMH, List<TblChiTietHd> a)
        {
            foreach (TblChiTietHd item in a)
            {
                if (item.MaHang.ToString().Equals(maMH))
                {
                    return true;
                }
            }
            return false;
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
        }

        public void giaTien()
        {
            MyOrderContext context = new MyOrderContext();
            float sum = 0;
            Dictionary<string, float> dict = new Dictionary<string, float>();
            var giaTien = context.TblMatHangs.ToList();
            foreach (TblMatHang item in giaTien)
            {
                dict.Add(item.TenHang, Convert.ToSingle(item.Gia));
            }
            if (dataGridView2.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    string tenMH = item.Cells[1].Value.ToString();
                    sum += dict[tenMH] * Convert.ToInt32(item.Cells[2].Value);
                }
            }
            textBox2.Text = sum.ToString("N0");
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            numericUpDown1.Value = 0;
            textBox2.Text = "0";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
