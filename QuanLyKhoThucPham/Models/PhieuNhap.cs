using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models;
public class PhieuNhap
{
    public PhieuNhap()
    {
        this.DSChiTietPhieuNhap = new HashSet<PhieuNhapChiTiet>();
    }

    [Key]
    public int MaPhieuNhap { get; set; }

    public DateTime NgayNhap { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn nhân viên")]
    public int MaNhanVien { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn kho nhập")]
    public int MaKho { get; set; }

    public int? MaNhaCungCap { get; set; }

    public decimal TongTien { get; set; }

    public string? Ghichu { get; set; }

    // Các mối quan hệ với các bảng khác
    public NhaCungCap? NhaCungCap { get; set; }

    // Mối quan hệ một-nhiều với PhieuNhapChiTiet
    public ICollection<PhieuNhapChiTiet> DSChiTietPhieuNhap { get; set; }
}
