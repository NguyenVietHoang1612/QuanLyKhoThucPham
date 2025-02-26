using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoThucPham.Migrations
{
    public partial class hello1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_NhaCungCap_NhaCungCapMaNhaCungCap",
                table: "SanPham");

            migrationBuilder.AlterColumn<int>(
                name: "NhaCungCapMaNhaCungCap",
                table: "SanPham",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MaNhaCungCap",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_NhaCungCap_NhaCungCapMaNhaCungCap",
                table: "SanPham",
                column: "NhaCungCapMaNhaCungCap",
                principalTable: "NhaCungCap",
                principalColumn: "MaNhaCungCap");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_NhaCungCap_NhaCungCapMaNhaCungCap",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "MaNhaCungCap",
                table: "SanPham");

            migrationBuilder.AlterColumn<int>(
                name: "NhaCungCapMaNhaCungCap",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_NhaCungCap_NhaCungCapMaNhaCungCap",
                table: "SanPham",
                column: "NhaCungCapMaNhaCungCap",
                principalTable: "NhaCungCap",
                principalColumn: "MaNhaCungCap",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
