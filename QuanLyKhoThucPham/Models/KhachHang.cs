using System.ComponentModel.DataAnnotations;

namespace KhoThucPham.Models
{
    public class KhachHang
    {
        public KhachHang() { 
            this.DSPhieuXuat = new HashSet<PhieuXuat>();
        }

        [Key]
        public int MaKhachHang { get; set; }

        public string HoTen {  get; set; }

        public string DiaChi { get; set; }

        public string Sdt { get; set; }

        public virtual ICollection<PhieuXuat> DSPhieuXuat { get; set; }
    }
}
