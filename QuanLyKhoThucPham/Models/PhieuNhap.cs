using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models
{
    public class PhieuNhap
    {
        public PhieuNhap()
        {
            this.DSChiTietPhieuNhap = new HashSet<PhieuNhapChiTiet>();
        }
        [Key]
        public int MaPhieuNhap { get; set; }

        public int MaPhieuNhapChiTiet {  get; set; }

        public DateTime NgayNhap { get; set; }

        public int MaNhanVien { get; set; }

        public int MaKho { get; set; }
    

        public int? MaNhaCungCap { get; set; }
  

        public decimal TongTien { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual KhoNhap KhoNhap { get; set; }
        public virtual NhanVien NhanVien { get; set; }

        public virtual ICollection<PhieuNhapChiTiet> DSChiTietPhieuNhap { get; set; }
    }
}
