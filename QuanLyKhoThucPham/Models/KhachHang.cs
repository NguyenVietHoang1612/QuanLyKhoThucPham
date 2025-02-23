using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models
{
    public class KhachHang
    {
      
        [Key]
        public int MaKhachHang { get; set; }

        public string HoTen {  get; set; }

        public string? DiaChi { get; set; }

        public string Sdt { get; set; }
    }
}
