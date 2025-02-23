using Microsoft.EntityFrameworkCore;
using QuanLyKhoThucPham.Models;

namespace QuanLyKhoThucPham.Data
{
    public class KhoThucPhamContext : DbContext
    {
        
        public KhoThucPhamContext(DbContextOptions<KhoThucPhamContext> options)
            : base(options)
        { }
        public DbSet<QuanLyKhoThucPham.Models.NhaCungCap> NhaCungCap { get; set; } = default!;

        public DbSet<QuanLyKhoThucPham.Models.SanPham>? SanPham { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.KhoNhap>? KhoNhap { get; set; }

        public DbSet<QuanLyKhoThucPham.Models.NhanVien>? NhanVien { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.KhachHang>? KhachHang { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.PhieuNhap>? PhieuNhap { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.PhieuXuat>? PhieuXuats { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.PhieuNhapChiTiet>? PhieuNhapChiTiet { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.PhieuXuatChiTiet>? PhieuXuatChiTiet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhaCungCap>().ToTable("NhaCungCap");
            modelBuilder.Entity<SanPham>().ToTable("SanPham");
            modelBuilder.Entity<KhoNhap>().ToTable("KhoNhap");
            modelBuilder.Entity<NhanVien>().ToTable("NhanVien");
            modelBuilder.Entity<KhachHang>().ToTable("KhachHang");
            modelBuilder.Entity<PhieuNhap>().ToTable("PhieuNhap");
            modelBuilder.Entity<PhieuXuat>().ToTable("PhieuXuat");
            modelBuilder.Entity<PhieuNhapChiTiet>()
                .HasKey(c => new { c.MaPhieuNhapChiTiet, c.MaSP });
            modelBuilder.Entity<PhieuXuatChiTiet>()
                .HasKey(c => new { c.MaPhieuXuatChiTiet, c.MaSP });
        }


    }
}
