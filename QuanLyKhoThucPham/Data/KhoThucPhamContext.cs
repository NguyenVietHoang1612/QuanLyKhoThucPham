using Microsoft.EntityFrameworkCore;

namespace KhoThucPham.Data
{
    public class KhoThucPhamContext : DbContext
    {
        
            public KhoThucPhamContext(DbContextOptions<KhoThucPhamContext> options)
               : base(options)
            { }
            public DbSet<KhoThucPham.Models.NhaCungCap> NhaCungCap { get; set; } = default!;

            public DbSet<KhoThucPham.Models.SanPham>? SanPham { get; set; }
            public DbSet<KhoThucPham.Models.KhoNhap>? KhoNhap { get; set; }

            public DbSet<KhoThucPham.Models.NhanVien>? NhanVien { get; set; }
            public DbSet<KhoThucPham.Models.KhachHang>? KhachHang { get; set; }
            public DbSet<KhoThucPham.Models.PhieuNhap>? PhieuNhap { get; set; }
            public DbSet<KhoThucPham.Models.PhieuXuat>? PhieuXuats { get; set; }
            public DbSet<KhoThucPham.Models.PhieuNhapChiTiet>? PhieuNhapChiTiet { get; set; }
            public DbSet<KhoThucPham.Models.PhieuXuatChiTiet>? PhieuXuatChiTiet { get; set; }



    }
}
