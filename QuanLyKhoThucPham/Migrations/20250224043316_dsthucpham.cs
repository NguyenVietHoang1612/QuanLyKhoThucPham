using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoThucPham.Migrations
{
    public partial class dsthucpham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "khoID",
                table: "dsthucpham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_dsthucpham_khoID",
                table: "dsthucpham",
                column: "khoID");

            migrationBuilder.AddForeignKey(
                name: "FK_dsthucpham_dskhohangModel_khoID",
                table: "dsthucpham",
                column: "khoID",
                principalTable: "dskhohangModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dsthucpham_dskhohangModel_khoID",
                table: "dsthucpham");

            migrationBuilder.DropIndex(
                name: "IX_dsthucpham_khoID",
                table: "dsthucpham");

            migrationBuilder.DropColumn(
                name: "khoID",
                table: "dsthucpham");
        }
    }
}
