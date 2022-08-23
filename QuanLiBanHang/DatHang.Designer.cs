
namespace QuanLiBanHang
{
    partial class DatHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDatMua = new System.Windows.Forms.Button();
            this.buttonTaoMoi = new System.Windows.Forms.Button();
            this.textBoxNgayDat = new System.Windows.Forms.TextBox();
            this.textBoxMaHD = new System.Windows.Forms.TextBox();
            this.textBoxDiaChi = new System.Windows.Forms.TextBox();
            this.textBoxTenKH = new System.Windows.Forms.TextBox();
            this.textBoxMaKH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonRtL = new System.Windows.Forms.Button();
            this.buttonLtR = new System.Windows.Forms.Button();
            this.textBoxSoLuong = new System.Windows.Forms.TextBox();
            this.textBoxGia = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonTroVe = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(322, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐƠN ĐẶT HÀNG";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDatMua);
            this.groupBox1.Controls.Add(this.buttonTaoMoi);
            this.groupBox1.Controls.Add(this.textBoxNgayDat);
            this.groupBox1.Controls.Add(this.textBoxMaHD);
            this.groupBox1.Controls.Add(this.textBoxDiaChi);
            this.groupBox1.Controls.Add(this.textBoxTenKH);
            this.groupBox1.Controls.Add(this.textBoxMaKH);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 244);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khách hàng";
            // 
            // buttonDatMua
            // 
            this.buttonDatMua.Location = new System.Drawing.Point(678, 188);
            this.buttonDatMua.Name = "buttonDatMua";
            this.buttonDatMua.Size = new System.Drawing.Size(112, 34);
            this.buttonDatMua.TabIndex = 12;
            this.buttonDatMua.Text = "Đặt mua";
            this.buttonDatMua.UseVisualStyleBackColor = true;
            // 
            // buttonTaoMoi
            // 
            this.buttonTaoMoi.Location = new System.Drawing.Point(539, 186);
            this.buttonTaoMoi.Name = "buttonTaoMoi";
            this.buttonTaoMoi.Size = new System.Drawing.Size(112, 34);
            this.buttonTaoMoi.TabIndex = 11;
            this.buttonTaoMoi.Text = "Tạo mới";
            this.buttonTaoMoi.UseVisualStyleBackColor = true;
            this.buttonTaoMoi.Click += new System.EventHandler(this.buttonTaoMoi_Click);
            // 
            // textBoxNgayDat
            // 
            this.textBoxNgayDat.Location = new System.Drawing.Point(614, 127);
            this.textBoxNgayDat.Name = "textBoxNgayDat";
            this.textBoxNgayDat.Size = new System.Drawing.Size(166, 31);
            this.textBoxNgayDat.TabIndex = 10;
            // 
            // textBoxMaHD
            // 
            this.textBoxMaHD.Location = new System.Drawing.Point(604, 60);
            this.textBoxMaHD.Name = "textBoxMaHD";
            this.textBoxMaHD.Size = new System.Drawing.Size(176, 31);
            this.textBoxMaHD.TabIndex = 9;
            // 
            // textBoxDiaChi
            // 
            this.textBoxDiaChi.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxDiaChi.Location = new System.Drawing.Point(146, 188);
            this.textBoxDiaChi.Name = "textBoxDiaChi";
            this.textBoxDiaChi.ReadOnly = true;
            this.textBoxDiaChi.Size = new System.Drawing.Size(342, 31);
            this.textBoxDiaChi.TabIndex = 8;
            // 
            // textBoxTenKH
            // 
            this.textBoxTenKH.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxTenKH.Location = new System.Drawing.Point(146, 127);
            this.textBoxTenKH.Name = "textBoxTenKH";
            this.textBoxTenKH.ReadOnly = true;
            this.textBoxTenKH.Size = new System.Drawing.Size(252, 31);
            this.textBoxTenKH.TabIndex = 6;
            // 
            // textBoxMaKH
            // 
            this.textBoxMaKH.Location = new System.Drawing.Point(146, 60);
            this.textBoxMaKH.Name = "textBoxMaKH";
            this.textBoxMaKH.Size = new System.Drawing.Size(150, 31);
            this.textBoxMaKH.TabIndex = 5;
            this.textBoxMaKH.TextChanged += new System.EventHandler(this.textBoxMaKH_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(478, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ngày đặt hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(478, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã hóa đơn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã khách hàng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.buttonRtL);
            this.groupBox2.Controls.Add(this.buttonLtR);
            this.groupBox2.Controls.Add(this.textBoxSoLuong);
            this.groupBox2.Controls.Add(this.textBoxGia);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.buttonTroVe);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(1, 365);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 301);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin mua hàng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(373, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 25);
            this.label10.TabIndex = 10;
            this.label10.Text = "Danh sách hàng mua";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(373, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(470, 241);
            this.dataGridView1.TabIndex = 9;
            // 
            // buttonRtL
            // 
            this.buttonRtL.Location = new System.Drawing.Point(303, 110);
            this.buttonRtL.Name = "buttonRtL";
            this.buttonRtL.Size = new System.Drawing.Size(51, 34);
            this.buttonRtL.TabIndex = 8;
            this.buttonRtL.Text = "<<";
            this.buttonRtL.UseVisualStyleBackColor = true;
            // 
            // buttonLtR
            // 
            this.buttonLtR.Location = new System.Drawing.Point(303, 52);
            this.buttonLtR.Name = "buttonLtR";
            this.buttonLtR.Size = new System.Drawing.Size(51, 34);
            this.buttonLtR.TabIndex = 7;
            this.buttonLtR.Text = ">>";
            this.buttonLtR.UseVisualStyleBackColor = true;
            // 
            // textBoxSoLuong
            // 
            this.textBoxSoLuong.Location = new System.Drawing.Point(102, 176);
            this.textBoxSoLuong.Name = "textBoxSoLuong";
            this.textBoxSoLuong.Size = new System.Drawing.Size(143, 31);
            this.textBoxSoLuong.TabIndex = 6;
            // 
            // textBoxGia
            // 
            this.textBoxGia.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxGia.Location = new System.Drawing.Point(102, 110);
            this.textBoxGia.Name = "textBoxGia";
            this.textBoxGia.ReadOnly = true;
            this.textBoxGia.Size = new System.Drawing.Size(143, 31);
            this.textBoxGia.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(102, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 33);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // buttonTroVe
            // 
            this.buttonTroVe.Location = new System.Drawing.Point(102, 239);
            this.buttonTroVe.Name = "buttonTroVe";
            this.buttonTroVe.Size = new System.Drawing.Size(112, 34);
            this.buttonTroVe.TabIndex = 3;
            this.buttonTroVe.Text = "Trở về";
            this.buttonTroVe.UseVisualStyleBackColor = true;
            this.buttonTroVe.Click += new System.EventHandler(this.buttonTroVe_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 25);
            this.label9.TabIndex = 2;
            this.label9.Text = "Số lượng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = "Giá";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mặt hàng";
            // 
            // DatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 670);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "DatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DatHang";
            this.Load += new System.EventHandler(this.DatHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDatMua;
        private System.Windows.Forms.Button buttonTaoMoi;
        private System.Windows.Forms.TextBox textBoxNgayDat;
        private System.Windows.Forms.TextBox textBoxMaHD;
        private System.Windows.Forms.TextBox textBoxDiaChi;
        private System.Windows.Forms.TextBox textBoxTenKH;
        private System.Windows.Forms.TextBox textBoxMaKH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRtL;
        private System.Windows.Forms.Button buttonLtR;
        private System.Windows.Forms.TextBox textBoxSoLuong;
        private System.Windows.Forms.TextBox textBoxGia;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonTroVe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}