using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models
{
    public class Quanlykhachhang
    {
        public int Id { get; set; }
        [Display(Name = "Tên Khách Hàng")]
        
        public string TenKH { get; set; }
        [Display(Name = "Mã Khách Hàng")]
        public string MaKH { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        public string Email { get; set; }
        [Display(Name = "SĐT")]
        public string SDT { get; set; }
        
    }
}
