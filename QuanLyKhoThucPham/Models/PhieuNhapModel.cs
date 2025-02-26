using System.ComponentModel.DataAnnotations;

namespace QuanLyKhoThucPham.Models;
public class PhieuNhapModel
{

    [Key]
    public int MaPhieuNhap { get; set; }

    public DateTime NgayNhap { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn nhân viên")]
    public int MaNhanVien { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn kho nhập")]
    public int MaKho { get; set; }

    public int MaNhaCungCap { get; set; }

    public decimal TongTien { get; set; }

    public string? Ghichu { get; set; }


    public NhaCungCapModel? NhaCungCap { get; set; }

    public ICollection<PhieuNhapChiTietModel>? DSChiTietPhieuNhap { get; set; }
}
