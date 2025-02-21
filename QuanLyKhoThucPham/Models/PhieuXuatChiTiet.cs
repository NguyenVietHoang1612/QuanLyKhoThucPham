using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhoThucPham.Models
{
    public class PhieuXuatChiTiet
    {
        [Key]
        public int MaPhieuXuatChiTiet { get; set; }

        public int? MaSP { get; set; }

        public int MaPhieuXuat { get; set; }

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }

        public decimal TongTIen { get; set; }

        public string GhiChu;

        public PhieuNhap PhieuXuat { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }

    }
}
