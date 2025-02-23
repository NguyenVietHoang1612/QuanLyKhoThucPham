﻿using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models
{
    public class PhieuXuat
    {
        public PhieuXuat()
        {
            this.DSChiTietPhieuXuat = new HashSet<PhieuXuatChiTiet>();
        }
        [Key]
        public int MaphieuXuat { get; set; }

        public DateTime NgayNhap { get; set; }

        public int MaNhanVien { get; set; }

        public int MaKho { get; set; }

        public int? MaKhachHang { get; set; }

        public decimal TongTien { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual ICollection<PhieuXuatChiTiet> DSChiTietPhieuXuat { get; set; }
    }
}
