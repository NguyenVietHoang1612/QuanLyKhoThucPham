using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoThucPham.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKhachHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "KhoNhap",
                columns: table => new
                {
                    MaKho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiThucPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoNhap", x => x.MaKho);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    MaNhaCungCap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhaCungCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.MaNhaCungCap);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNhanVien);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TonKho = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonGiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaNhaCungCap = table.Column<int>(type: "int", nullable: false),
                    NhaCungCapMaNhaCungCap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SanPham_NhaCungCap_NhaCungCapMaNhaCungCap",
                        column: x => x.NhaCungCapMaNhaCungCap,
                        principalTable: "NhaCungCap",
                        principalColumn: "MaNhaCungCap",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhap",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    MaKho = table.Column<int>(type: "int", nullable: false),
                    MaNhaCungCap = table.Column<int>(type: "int", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhaCungCapMaNhaCungCap = table.Column<int>(type: "int", nullable: true),
                    KhoNhapMaKho = table.Column<int>(type: "int", nullable: false),
                    NhanVienMaNhanVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhap", x => x.MaPhieuNhap);
                    table.ForeignKey(
                        name: "FK_PhieuNhap_KhoNhap_KhoNhapMaKho",
                        column: x => x.KhoNhapMaKho,
                        principalTable: "KhoNhap",
                        principalColumn: "MaKho",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuNhap_NhaCungCap_NhaCungCapMaNhaCungCap",
                        column: x => x.NhaCungCapMaNhaCungCap,
                        principalTable: "NhaCungCap",
                        principalColumn: "MaNhaCungCap");
                    table.ForeignKey(
                        name: "FK_PhieuNhap_NhanVien_NhanVienMaNhanVien",
                        column: x => x.NhanVienMaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuXuat",
                columns: table => new
                {
                    MaphieuXuat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    MaKho = table.Column<int>(type: "int", nullable: false),
                    MaKhachHang = table.Column<int>(type: "int", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KhachHangMaKhachHang = table.Column<int>(type: "int", nullable: false),
                    KhoNhapMaKho = table.Column<int>(type: "int", nullable: false),
                    NhanVienMaNhanVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuXuat", x => x.MaphieuXuat);
                    table.ForeignKey(
                        name: "FK_PhieuXuat_KhachHang_KhachHangMaKhachHang",
                        column: x => x.KhachHangMaKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuXuat_KhoNhap_KhoNhapMaKho",
                        column: x => x.KhoNhapMaKho,
                        principalTable: "KhoNhap",
                        principalColumn: "MaKho",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuXuat_NhanVien_NhanVienMaNhanVien",
                        column: x => x.NhanVienMaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhapChiTiet",
                columns: table => new
                {
                    MaPhieuNhapChiTiet = table.Column<int>(type: "int", nullable: false),
                    MaSP = table.Column<int>(type: "int", nullable: false),
                    MaPhieuNhap = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongTIen = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhieuNhapMaPhieuNhap = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhapChiTiet", x => new { x.MaPhieuNhapChiTiet, x.MaSP });
                    table.ForeignKey(
                        name: "FK_PhieuNhapChiTiet_PhieuNhap_PhieuNhapMaPhieuNhap",
                        column: x => x.PhieuNhapMaPhieuNhap,
                        principalTable: "PhieuNhap",
                        principalColumn: "MaPhieuNhap");
                    table.ForeignKey(
                        name: "FK_PhieuNhapChiTiet_SanPham_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuXuatChiTiet",
                columns: table => new
                {
                    MaPhieuXuatChiTiet = table.Column<int>(type: "int", nullable: false),
                    MaSP = table.Column<int>(type: "int", nullable: false),
                    MaPhieuXuat = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongTIen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhieuXuatMaPhieuNhap = table.Column<int>(type: "int", nullable: false),
                    PhieuXuatMaphieuXuat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuXuatChiTiet", x => new { x.MaPhieuXuatChiTiet, x.MaSP });
                    table.ForeignKey(
                        name: "FK_PhieuXuatChiTiet_PhieuNhap_PhieuXuatMaPhieuNhap",
                        column: x => x.PhieuXuatMaPhieuNhap,
                        principalTable: "PhieuNhap",
                        principalColumn: "MaPhieuNhap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuXuatChiTiet_PhieuXuat_PhieuXuatMaphieuXuat",
                        column: x => x.PhieuXuatMaphieuXuat,
                        principalTable: "PhieuXuat",
                        principalColumn: "MaphieuXuat");
                    table.ForeignKey(
                        name: "FK_PhieuXuatChiTiet_SanPham_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_KhoNhapMaKho",
                table: "PhieuNhap",
                column: "KhoNhapMaKho");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_NhaCungCapMaNhaCungCap",
                table: "PhieuNhap",
                column: "NhaCungCapMaNhaCungCap");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_NhanVienMaNhanVien",
                table: "PhieuNhap",
                column: "NhanVienMaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapChiTiet_MaSP",
                table: "PhieuNhapChiTiet",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhapChiTiet_PhieuNhapMaPhieuNhap",
                table: "PhieuNhapChiTiet",
                column: "PhieuNhapMaPhieuNhap");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_KhachHangMaKhachHang",
                table: "PhieuXuat",
                column: "KhachHangMaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_KhoNhapMaKho",
                table: "PhieuXuat",
                column: "KhoNhapMaKho");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_NhanVienMaNhanVien",
                table: "PhieuXuat",
                column: "NhanVienMaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuatChiTiet_MaSP",
                table: "PhieuXuatChiTiet",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuatChiTiet_PhieuXuatMaPhieuNhap",
                table: "PhieuXuatChiTiet",
                column: "PhieuXuatMaPhieuNhap");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuatChiTiet_PhieuXuatMaphieuXuat",
                table: "PhieuXuatChiTiet",
                column: "PhieuXuatMaphieuXuat");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_NhaCungCapMaNhaCungCap",
                table: "SanPham",
                column: "NhaCungCapMaNhaCungCap");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuNhapChiTiet");

            migrationBuilder.DropTable(
                name: "PhieuXuatChiTiet");

            migrationBuilder.DropTable(
                name: "PhieuNhap");

            migrationBuilder.DropTable(
                name: "PhieuXuat");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "KhoNhap");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "NhaCungCap");
        }
    }
}
