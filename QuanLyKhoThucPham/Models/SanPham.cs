using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoThucPham.Models
{
    public class SanPham
    {
        [Key]
        public int MaSP { get; set; }

        [Required]
        public string TenSanPham { get; set; }

        public int TonKho { get; set; }

        public decimal DonGia { get; set; }  
        public decimal DonGiaNhap { get; set; }

        public int MaNhaCungCap { get; set; }
        public NhaCungCap NhaCungCap { get; set; }

    }
    

}
