using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhoThucPham.Models
{
    public class PhieuNhapChiTiet
    {
        [Key]
        public int MaPhieuNhapChiTiet { get; set; }

        public int? MaSP { get; set; }

        public int MaPhieuNhap {get; set;}

        public int SoLuong {  get; set;}

        public decimal DonGia { get; set;}  

        public decimal TongTIen { get; set;}

        public string GhiChu;

        public PhieuNhap PhieuNhap { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }
    }
}
