using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models
{
    public class KhoHangModel
    {
        [Key]
        public int MaKho { get; set; }
        public string TenKho { get; set; }
        public string mota { get; set; }

        public int soluongtong { get; set; }
        public int soluongtrong { get; set; }

       
    }
}
