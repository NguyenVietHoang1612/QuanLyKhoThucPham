using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models
{
    public class KhoNhap
    {
        [Key]
        public int MaKho { get; set; }
        public string TenKho { get; set; }

        public string LoaiThucPham { get; set; }

        public string? GhiChu { get; set; }

    }
}
