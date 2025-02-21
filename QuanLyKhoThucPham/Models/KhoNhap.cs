using System.ComponentModel.DataAnnotations;

namespace KhoThucPham.Models
{
    public class KhoNhap
    {
        [Key]
        public int MaKho { get; set; }
        public string TenKho { get; set; }

        public int MaSanPham { get; set; }

        public string LoaiThucPham { get; set; }

        public string GhiChu { get; set; }

        public static SanPham SanPham { get; set;}
    }
}
