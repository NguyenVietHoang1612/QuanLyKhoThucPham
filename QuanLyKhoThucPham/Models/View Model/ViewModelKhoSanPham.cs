using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models.View_Model
{
    public class ViewModelKhoSanPham
    {
        public List<KhoHangModel> DSKhoHang { get; set; } = new List<KhoHangModel>();

        public SanPhamModel SanPham { get; set; } 
        public List<SanPhamModel> DSSanPham { get; set; } = new List<SanPhamModel>();
    }
}
