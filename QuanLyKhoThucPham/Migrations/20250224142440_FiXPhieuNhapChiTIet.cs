using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoThucPham.Migrations
{
    public partial class FiXPhieuNhapChiTIet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SanPhamMaSP",
                table: "KhoNhap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KhoNhap_SanPhamMaSP",
                table: "KhoNhap",
                column: "SanPhamMaSP");

            migrationBuilder.AddForeignKey(
                name: "FK_KhoNhap_SanPham_SanPhamMaSP",
                table: "KhoNhap",
                column: "SanPhamMaSP",
                principalTable: "SanPham",
                principalColumn: "MaSP",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhoNhap_SanPham_SanPhamMaSP",
                table: "KhoNhap");

            migrationBuilder.DropIndex(
                name: "IX_KhoNhap_SanPhamMaSP",
                table: "KhoNhap");

            migrationBuilder.DropColumn(
                name: "SanPhamMaSP",
                table: "KhoNhap");
        }
    }
}
