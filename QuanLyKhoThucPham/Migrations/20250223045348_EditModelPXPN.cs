using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoThucPham.Migrations
{
    public partial class EditModelPXPN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhap_KhoNhap_KhoNhapMaKho",
                table: "PhieuNhap");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhap_NhanVien_NhanVienMaNhanVien",
                table: "PhieuNhap");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuXuat_KhoNhap_KhoNhapMaKho",
                table: "PhieuXuat");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuXuat_NhanVien_NhanVienMaNhanVien",
                table: "PhieuXuat");

            migrationBuilder.DropIndex(
                name: "IX_PhieuXuat_KhoNhapMaKho",
                table: "PhieuXuat");

            migrationBuilder.DropIndex(
                name: "IX_PhieuXuat_NhanVienMaNhanVien",
                table: "PhieuXuat");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhap_KhoNhapMaKho",
                table: "PhieuNhap");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhap_NhanVienMaNhanVien",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "KhoNhapMaKho",
                table: "PhieuXuat");

            migrationBuilder.DropColumn(
                name: "NhanVienMaNhanVien",
                table: "PhieuXuat");

            migrationBuilder.DropColumn(
                name: "KhoNhapMaKho",
                table: "PhieuNhap");

            migrationBuilder.DropColumn(
                name: "NhanVienMaNhanVien",
                table: "PhieuNhap");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KhoNhapMaKho",
                table: "PhieuXuat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NhanVienMaNhanVien",
                table: "PhieuXuat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KhoNhapMaKho",
                table: "PhieuNhap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NhanVienMaNhanVien",
                table: "PhieuNhap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_KhoNhapMaKho",
                table: "PhieuXuat",
                column: "KhoNhapMaKho");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuXuat_NhanVienMaNhanVien",
                table: "PhieuXuat",
                column: "NhanVienMaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_KhoNhapMaKho",
                table: "PhieuNhap",
                column: "KhoNhapMaKho");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_NhanVienMaNhanVien",
                table: "PhieuNhap",
                column: "NhanVienMaNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhap_KhoNhap_KhoNhapMaKho",
                table: "PhieuNhap",
                column: "KhoNhapMaKho",
                principalTable: "KhoNhap",
                principalColumn: "MaKho",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhap_NhanVien_NhanVienMaNhanVien",
                table: "PhieuNhap",
                column: "NhanVienMaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuXuat_KhoNhap_KhoNhapMaKho",
                table: "PhieuXuat",
                column: "KhoNhapMaKho",
                principalTable: "KhoNhap",
                principalColumn: "MaKho",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuXuat_NhanVien_NhanVienMaNhanVien",
                table: "PhieuXuat",
                column: "NhanVienMaNhanVien",
                principalTable: "NhanVien",
                principalColumn: "MaNhanVien",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
