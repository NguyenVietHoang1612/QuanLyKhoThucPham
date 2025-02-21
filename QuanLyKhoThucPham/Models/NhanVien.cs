using System.ComponentModel.DataAnnotations;

namespace KhoThucPham.Models
{
    public class NhanVien
    {
        public NhanVien() { 
        
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Mã Nhân Viên")]
        public string MaNhanVien { get; set; }


        [Required]
        [Display(Name = "Họ Tên Nhân Viên")]
        public string HoTen { get; set; }

        [Required]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Display(Name = "Chức Vụ")]
        public string ChucVu { get; set; }

        public virtual ICollection<PhieuNhap> DSPhieuNhap { get; set; }
        public virtual ICollection<PhieuXuat> DSPhieuXuat { get; set; }
    }
}
