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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadData();
            this.BackColor = Color.DarkOrange;
            dataGridView1.ClearSelection();

            textBoxMa.Text = "(không cần điền)";
            textBoxDiaChi.Clear();
            textBoxTen.Clear();
        }

        private void loadData()
        {
            using (MyOrderContext context = new MyOrderContext())
            {
                textBoxTen.Focus();
                buttonXoa.Enabled = false;
                buttonSua.Enabled = false;
                buttonCapNhat.Enabled = false;
                var data1 = context.TblKhachHangs.ToList().Select(item => new
                {
                    MãKH = item.MaKh,
                    TênKH = item.TenKh,
                    GiớiTính = GioiTinh(item),
                    ĐịaChỉ = item.DiaChi,
                    NgàySinh = item.NgaySinh.Value.Day + "/" + item.NgaySinh.Value.Month + "/" +
                               item.NgaySinh.Value.Year
                }).ToList();
                dataGridView1.DataSource = data1;
            }
        }

        public string GioiTinh(TblKhachHang a)
        {
            if (a.GioiTinh)
            {
                return "Nam";
            }
            else return "Nữ";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            textBoxMa.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString().Equals("Nam"))
            {
                radioButton1.Checked = true;
            }
            else radioButton2.Checked = true;
            textBoxDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string[] DOB = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Split("/");
            DateTime day = new
            DateTime(Convert.ToInt32(DOB[2]), Convert.ToInt32(DOB[1]), Convert.ToInt32(DOB[0]));
            dateTimePicker1.Value = day;
            buttonSua.Enabled = true;
        }

        private void buttonMoi_Click(object sender, EventArgs e)
        {
            textBoxMa.Text = "(không cần điền)";
            textBoxTen.Text = "";
            textBoxDiaChi.Text = "";
            buttonCapNhat.Enabled = false;
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            dataGridView1.ClearSelection();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (textBoxTen.Text.Length == 0 | textBoxDiaChi.Text.Length == 0)
            {
                MessageBox.Show("Thêm khách hàng thất bại. Các ô thông tin không được rỗng");
            }
            else
            {
                using (MyOrderContext context = new MyOrderContext())
                {
                    List<TblKhachHang> list = context.TblKhachHangs.ToList();
                    string[] split = list[list.Count - 1].MaKh.Split("H");
                    int num = Convert.ToInt32(split[1]);
                    string code;
                    if ((num + 1) >= 10)
                    {
                        code = "KH" + (num + 1);
                    }
                    else code = "KH0" + (num + 1);
                    bool gen = false;
                    if (radioButton1.Checked)
                    {
                        gen = true;
                    }
                    TblKhachHang a = new TblKhachHang();
                    a.MaKh = code;
                    a.TenKh = textBoxTen.Text;
                    a.GioiTinh = gen;
                    a.DiaChi = textBoxDiaChi.Text;
                    a.NgaySinh = dateTimePicker1.Value;
                    context.TblKhachHangs.Add(a);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Thêm khách hàng thành công");
                        loadData();
                    }
                }
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            buttonCapNhat.Enabled = true;
            buttonXoa.Enabled = true;
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn cập nhật?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (MyOrderContext context = new MyOrderContext())
                {
                    bool gen = false;
                    if (radioButton1.Checked)
                    {
                        gen = true;
                    }
                    TblKhachHang pro = context.TblKhachHangs.SingleOrDefault(
                        item => item.MaKh == textBoxMa.Text);
                    pro.TenKh = textBoxTen.Text;
                    pro.NgaySinh = dateTimePicker1.Value;
                    pro.GioiTinh = gen;
                    pro.DiaChi = textBoxDiaChi.Text;
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        loadData();
                    }
                    else loadData();
                }
            }
            else loadData();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (MyOrderContext context = new MyOrderContext())
                {
                    TblKhachHang pro = context.TblKhachHangs.SingleOrDefault(
                        item => item.MaKh == textBoxMa.Text);
                    context.TblKhachHangs.Remove(pro);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        loadData();
                    }
                }
            }
            else
            {
                loadData();
            }
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
    }
}
