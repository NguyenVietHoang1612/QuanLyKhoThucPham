
using System.ComponentModel.DataAnnotations;

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
        public int MaNhaCungCap { get; set; }
        public NhaCungCapModel? NhaCungCap { get; set; }

    }
}
