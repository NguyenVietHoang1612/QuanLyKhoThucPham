using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models;
public class PhieuNhapChiTiet
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
    public string? GhiChu { get; set; }

    public PhieuNhap? PhieuNhap { get; set; }
    public SanPham? SanPham { get; set; }
}
