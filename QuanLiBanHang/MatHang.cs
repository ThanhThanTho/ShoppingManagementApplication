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
    public partial class MatHang : Form
    {
        public MatHang()
        {
            InitializeComponent();
        }

        private void MatHang_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadData();
            this.BackColor = Color.DarkOrange;
            dataGridView1.ClearSelection();
        }

        private void loadData()
        {
            buttonCapNhat.Enabled = false;
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            using (MyOrderContext context = new MyOrderContext())
            {
                var data = context.TblMatHangs.ToList().Select(item => new
                {
                    MãHàng = item.MaHang,
                    TênHàng = item.TenHang,
                    Đơnvị = item.Dvt,
                    Giá = Convert.ToDouble(item.Gia).ToString("N0")
                }).ToList();
                dataGridView1.DataSource = data;
                comboBoxDonVi.Text = "Chiếc";

                var data1 = context.TblMatHangs.ToList();
                foreach (TblMatHang item in data1)
                {
                    if (!comboBoxDonVi.Items.Contains(item.Dvt))
                    {
                        comboBoxDonVi.Items.Add(item.Dvt);
                    }
                }
                dataGridView1.ClearSelection();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            textBoxMa.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBoxDonVi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxGiaBan.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            buttonSua.Enabled = true;
        }

        private void buttonMoi_Click(object sender, EventArgs e)
        {
            textBoxMa.Text = "";
            textBoxTen.Text = "";
            textBoxGiaBan.Text = "";
            loadData();
            dataGridView1.ClearSelection();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            float a;
            if (textBoxMa.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã hàng");
            }
            else if (textBoxTen.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên hàng");
            }
            else if (textBoxGiaBan.Text.Length == 0 | !float.TryParse(textBoxGiaBan.Text, out a))
            {
                MessageBox.Show("Giá bán không hợp lệ");
            }
            else
            {
                using (MyOrderContext context = new MyOrderContext())
                {
                    TblMatHang matHang = new TblMatHang();
                    matHang.MaHang = textBoxMa.Text;
                    matHang.TenHang = textBoxTen.Text;
                    matHang.Dvt = comboBoxDonVi.Text;
                    matHang.Gia = Convert.ToSingle(textBoxGiaBan.Text);
                    context.TblMatHangs.Add(matHang);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Thêm mặt hàng thành công");
                        loadData();
                    }
                    else loadData();
                }
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            buttonCapNhat.Enabled = true;
            buttonXoa.Enabled = true;
            textBoxMa.ReadOnly = true;
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            float a;
            if (MessageBox.Show("Bạn có chắc muốn cập nhật?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (textBoxTen.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa nhập tên hàng");
                }
                else if (textBoxGiaBan.Text.Length == 0 | !float.TryParse(textBoxGiaBan.Text, out a))
                {
                    MessageBox.Show("Giá bán không hợp lệ");
                }
                else
                {
                    using (MyOrderContext context = new MyOrderContext())
                    {
                        TblMatHang pro = context.TblMatHangs.SingleOrDefault(
                            item => item.MaHang.Equals(textBoxMa.Text));
                        pro.TenHang = textBoxTen.Text;
                        pro.Dvt = comboBoxDonVi.Text;
                        pro.Gia = Convert.ToSingle(textBoxGiaBan.Text);
                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            loadData();
                        }
                        else loadData();
                    }
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
                    TblMatHang pro = context.TblMatHangs.SingleOrDefault(
                            item => item.MaHang.Equals(textBoxMa.Text));
                    context.TblMatHangs.Remove(pro);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        loadData();
                    }
                    else loadData();
                }
            }
            else loadData();
        }

        private void buttonTroVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLy a = new QuanLy();
            a.ShowDialog();
            this.Close();
        }
    }
}
