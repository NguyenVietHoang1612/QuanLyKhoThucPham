using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNhanVien { get; set; }

        [Required]
        [Display(Name = "Họ Tên Nhân Viên")]
        public string HoTen { get; set; }

        [Required]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Display(Name = "Chức Vụ")]
        public string ChucVu { get; set; }

    }
}
