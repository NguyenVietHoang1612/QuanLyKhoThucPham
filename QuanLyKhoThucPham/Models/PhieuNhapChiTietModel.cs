
using System.ComponentModel.DataAnnotations;



namespace QuanLyKhoThucPham.Models;

public class PhieuNhapChiTietModel
{
    [Key]
    [Required]
    public int MaPhieuNhapChiTiet { get; set; }
    [Key]
    [Required(ErrorMessage = "Vui lòng chọn sản phẩm")]
    public int MaSP { get; set; }

    public int MaPhieuNhap { get; set; }  

    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public decimal? TongTIen { get; set; }

    public PhieuNhapModel? PhieuNhap { get; set; }
    public SanPhamModel? SanPham { get; set; }
}
