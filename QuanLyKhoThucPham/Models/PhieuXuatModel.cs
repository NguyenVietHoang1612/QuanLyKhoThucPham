using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models
{
    public class PhieuXuatModel
    {
        [Key]
        public int MaphieuXuat { get; set; }

        public DateTime NgayXuat { get; set; }

        public int MaNhanVien { get; set; }

        public int MaKho { get; set; }

        public int MaKhachHang { get; set; }

        public decimal TongTien { get; set; }
        public string? Ghichu { get; set; }

        public virtual KhachHangModel KhachHang { get; set; }

        public virtual ICollection<PhieuXuatChiTietModel> DSChiTietPhieuXuat { get; set; }
    }
}
