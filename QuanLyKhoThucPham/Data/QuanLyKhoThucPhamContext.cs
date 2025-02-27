using Microsoft.EntityFrameworkCore;
using QuanLyKhoThucPham.Models;

namespace QuanLyKhoThucPham.Data
{
    public class QuanLyKhoThucPhamContext : DbContext
    {
        
        public QuanLyKhoThucPhamContext(DbContextOptions<QuanLyKhoThucPhamContext> options)
            : base(options)
        { }
        public DbSet<QuanLyKhoThucPham.Models.NhaCungCapModel>? NhaCungCap { get; set; }

        public DbSet<QuanLyKhoThucPham.Models.SanPhamModel>? SanPham { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.KhoHangModel>? KhoHang { get; set; } 

        public DbSet<QuanLyKhoThucPham.Models.NhanVienModel>? NhanVien { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.KhachHangModel>? KhachHang { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.PhieuNhapModel>? PhieuNhap { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.PhieuXuatModel>? PhieuXuat { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.PhieuNhapChiTietModel>? PhieuNhapChiTiet { get; set; }
        public DbSet<QuanLyKhoThucPham.Models.PhieuXuatChiTietModel>? PhieuXuatChiTiet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhaCungCapModel>().ToTable("NhaCungCap");
            modelBuilder.Entity<SanPhamModel>().ToTable("SanPham");
            modelBuilder.Entity<KhoHangModel>().ToTable("KhoHang");
            modelBuilder.Entity<NhanVienModel>().ToTable("NhanVien");
            modelBuilder.Entity<KhachHangModel>().ToTable("KhachHang");
            modelBuilder.Entity<PhieuNhapModel>().ToTable("PhieuNhap");
            modelBuilder.Entity<PhieuXuatModel>().ToTable("PhieuXuat");
        }


    }
}
