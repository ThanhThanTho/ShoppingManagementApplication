using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLiBanHang.Models
{
    public partial class TblKhachHang
    {
        public TblKhachHang()
        {
            TblHoadons = new HashSet<TblHoadon>();
        }

        public string MaKh { get; set; }
        public string TenKh { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgaySinh { get; set; }

        public virtual ICollection<TblHoadon> TblHoadons { get; set; }
    }
}
