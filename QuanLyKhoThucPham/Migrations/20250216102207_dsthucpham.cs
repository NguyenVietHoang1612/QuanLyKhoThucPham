using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKhoThucPham.Migrations
{
    public partial class dsthucpham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dsthucpham",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soluong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaysx = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hsd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nhasanxuat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dsthucpham", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dsthucpham");
        }
    }
}
