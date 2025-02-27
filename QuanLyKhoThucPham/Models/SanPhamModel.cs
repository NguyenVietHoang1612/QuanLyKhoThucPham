
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoThucPham.Models
{
    public class SanPhamModel
    {
        [Key]
        public int MaSP { get; set; }
        public string TenSP { get; set; }

        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string NhaSanXuat { get; set; }
        public string? MoTa { get; set; }

    }
}
