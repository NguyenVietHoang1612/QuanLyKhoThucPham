using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoThucPham.Models
{
    public class PhieuXuatChiTietModel
    {
        [Key]
        public int MaPhieuXuatChiTiet { get; set; }

        [Key]
        public int MaSP { get; set; }

        public int MaPhieuXuat { get; set; }

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }

        public decimal TongTIen { get; set; }

        public string? GhiChu { get; set; }

        public PhieuXuatModel PhieuXuat { get; set; }
        public SanPhamModel SanPham { get; set; }

    }
}
