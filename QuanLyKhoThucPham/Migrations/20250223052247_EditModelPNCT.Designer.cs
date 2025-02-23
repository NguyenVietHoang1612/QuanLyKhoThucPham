﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyKhoThucPham.Data;

#nullable disable

namespace QuanLyKhoThucPham.Migrations
{
    [DbContext(typeof(KhoThucPhamContext))]
    [Migration("20250223052247_EditModelPNCT")]
    partial class EditModelPNCT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuanLyKhoThucPham.Models.KhachHang", b =>
                {
                    b.Property<int>("MaKhachHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKhachHang"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKhachHang");

                    b.ToTable("KhachHang", (string)null);
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.KhoNhap", b =>
                {
                    b.Property<int>("MaKho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKho"), 1L, 1);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoaiThucPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKho");

                    b.ToTable("KhoNhap", (string)null);
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.NhaCungCap", b =>
                {
                    b.Property<int>("MaNhaCungCap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNhaCungCap"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNhaCungCap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNhaCungCap");

                    b.ToTable("NhaCungCap", (string)null);
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.NhanVien", b =>
                {
                    b.Property<int>("MaNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNhanVien"), 1L, 1);

                    b.Property<string>("ChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNhanVien");

                    b.ToTable("NhanVien", (string)null);
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuNhap", b =>
                {
                    b.Property<int>("MaPhieuNhap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhieuNhap"), 1L, 1);

                    b.Property<string>("Ghichu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaKho")
                        .HasColumnType("int");

                    b.Property<int?>("MaNhaCungCap")
                        .HasColumnType("int");

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NhaCungCapMaNhaCungCap")
                        .HasColumnType("int");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaPhieuNhap");

                    b.HasIndex("NhaCungCapMaNhaCungCap");

                    b.ToTable("PhieuNhap", (string)null);
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuNhapChiTiet", b =>
                {
                    b.Property<int>("MaPhieuNhapChiTiet")
                        .HasColumnType("int");

                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaPhieuNhap")
                        .HasColumnType("int");

                    b.Property<int?>("PhieuNhapMaPhieuNhap")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal?>("TongTIen")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaPhieuNhapChiTiet", "MaSP");

                    b.HasIndex("MaSP");

                    b.HasIndex("PhieuNhapMaPhieuNhap");

                    b.ToTable("PhieuNhapChiTiet");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuXuat", b =>
                {
                    b.Property<int>("MaphieuXuat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaphieuXuat"), 1L, 1);

                    b.Property<int>("KhachHangMaKhachHang")
                        .HasColumnType("int");

                    b.Property<int?>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<int>("MaKho")
                        .HasColumnType("int");

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaphieuXuat");

                    b.HasIndex("KhachHangMaKhachHang");

                    b.ToTable("PhieuXuat", (string)null);
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuXuatChiTiet", b =>
                {
                    b.Property<int>("MaPhieuXuatChiTiet")
                        .HasColumnType("int");

                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaPhieuXuat")
                        .HasColumnType("int");

                    b.Property<int>("PhieuXuatMaPhieuNhap")
                        .HasColumnType("int");

                    b.Property<int?>("PhieuXuatMaphieuXuat")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal>("TongTIen")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaPhieuXuatChiTiet", "MaSP");

                    b.HasIndex("MaSP");

                    b.HasIndex("PhieuXuatMaPhieuNhap");

                    b.HasIndex("PhieuXuatMaphieuXuat");

                    b.ToTable("PhieuXuatChiTiet");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.SanPham", b =>
                {
                    b.Property<int>("MaSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSP"), 1L, 1);

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DonGiaNhap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaNhaCungCap")
                        .HasColumnType("int");

                    b.Property<int>("NhaCungCapMaNhaCungCap")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TonKho")
                        .HasColumnType("int");

                    b.HasKey("MaSP");

                    b.HasIndex("NhaCungCapMaNhaCungCap");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuNhap", b =>
                {
                    b.HasOne("QuanLyKhoThucPham.Models.NhaCungCap", "NhaCungCap")
                        .WithMany()
                        .HasForeignKey("NhaCungCapMaNhaCungCap");

                    b.Navigation("NhaCungCap");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuNhapChiTiet", b =>
                {
                    b.HasOne("QuanLyKhoThucPham.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("MaSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhoThucPham.Models.PhieuNhap", "PhieuNhap")
                        .WithMany("DSChiTietPhieuNhap")
                        .HasForeignKey("PhieuNhapMaPhieuNhap");

                    b.Navigation("PhieuNhap");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuXuat", b =>
                {
                    b.HasOne("QuanLyKhoThucPham.Models.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("KhachHangMaKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuXuatChiTiet", b =>
                {
                    b.HasOne("QuanLyKhoThucPham.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("MaSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhoThucPham.Models.PhieuNhap", "PhieuXuat")
                        .WithMany()
                        .HasForeignKey("PhieuXuatMaPhieuNhap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhoThucPham.Models.PhieuXuat", null)
                        .WithMany("DSChiTietPhieuXuat")
                        .HasForeignKey("PhieuXuatMaphieuXuat");

                    b.Navigation("PhieuXuat");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.SanPham", b =>
                {
                    b.HasOne("QuanLyKhoThucPham.Models.NhaCungCap", "NhaCungCap")
                        .WithMany()
                        .HasForeignKey("NhaCungCapMaNhaCungCap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhaCungCap");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuNhap", b =>
                {
                    b.Navigation("DSChiTietPhieuNhap");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuXuat", b =>
                {
                    b.Navigation("DSChiTietPhieuXuat");
                });
#pragma warning restore 612, 618
        }
    }
}
