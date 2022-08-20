using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLiBanHang.Models
{
    public partial class TblChiTietHd
    {
        public decimal MaChiTietHd { get; set; }
        public decimal MaHd { get; set; }
        public string MaHang { get; set; }
        public int SoLuong { get; set; }

        public virtual TblMatHang MaHangNavigation { get; set; }
        public virtual TblHoadon MaHdNavigation { get; set; }
    }
}
