using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoThucPham.Migrations
{
    public partial class suamodelkhachhang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quanlykhachhang",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quanlykhachhang", x => x.MaKH);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quanlykhachhang");
        }
    }
}
