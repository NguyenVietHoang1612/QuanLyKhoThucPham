using Microsoft.EntityFrameworkCore;


namespace QuanLyKhoThucPham.Data    

{
    public class QuanLyKhoThucPhamContext : DbContext
    {
        public QuanLyKhoThucPhamContext (DbContextOptions<QuanLyKhoThucPhamContext> options)
            : base(options)
        {
        }



        public DbSet<QuanLyKhoThucPham.Models.NhanVien>? NhanVien { get; set; } = default!;

        public DbSet<QuanLyKhoThucPham.Models.KhachHang>? KhachHang { get; set; } = default!;

        public DbSet<QuanLyKhoThucPham.Models.NhaCungCap>? NhaCungCap { get; set; }

        public DbSet<QuanLyKhoThucPham.Models.KhoHang> KhoHang { get; set; } = default!;

        public DbSet<QuanLyKhoThucPham.Models.SanPham>? SanPham { get; set; }

    }
}
