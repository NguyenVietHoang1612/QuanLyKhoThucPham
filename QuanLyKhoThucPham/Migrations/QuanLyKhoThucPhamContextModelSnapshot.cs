﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyKhoThucPham.Data;

#nullable disable

namespace QuanLyKhoThucPham.Migrations
{
    [DbContext(typeof(QuanLyKhoThucPhamContext))]
    partial class QuanLyKhoThucPhamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuanLyKhoThucPham.Models.KhachHangModel", b =>
                {
                    b.Property<int>("MaKH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKH"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKH");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.KhoHangModel", b =>
                {
                    b.Property<int>("MaKho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKho"), 1L, 1);

                    b.Property<string>("KhoLoaiSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("soluongtong")
                        .HasColumnType("int");

                    b.Property<int?>("soluongtrong")
                        .HasColumnType("int");

                    b.HasKey("MaKho");

                    b.ToTable("KhoHang");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.NhaCungCapModel", b =>
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

                    b.ToTable("NhaCungCap");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.NhanVienModel", b =>
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

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuNhapChiTietModel", b =>
                {
                    b.Property<int>("MaPhieuNhapChiTiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhieuNhapChiTiet"), 1L, 1);

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaPhieuNhap")
                        .HasColumnType("int");

                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal?>("TongTIen")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaPhieuNhapChiTiet");

                    b.HasIndex("MaPhieuNhap");

                    b.HasIndex("MaSP");

                    b.ToTable("PhieuNhapChiTiet");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuNhapModel", b =>
                {
                    b.Property<int>("MaPhieuNhap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhieuNhap"), 1L, 1);

                    b.Property<string>("Ghichu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaKho")
                        .HasColumnType("int");

                    b.Property<int>("MaNhaCungCap")
                        .HasColumnType("int");

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaPhieuNhap");

                    b.HasIndex("MaKho");

                    b.HasIndex("MaNhaCungCap");

                    b.HasIndex("MaNhanVien");

                    b.ToTable("PhieuNhap");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuXuatChiTietModel", b =>
                {
                    b.Property<int>("MaPhieuXuatChiTiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhieuXuatChiTiet"), 1L, 1);

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaPhieuXuat")
                        .HasColumnType("int");

                    b.Property<int>("MaSP")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal>("TongTIen")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaPhieuXuatChiTiet");

                    b.HasIndex("MaPhieuXuat");

                    b.HasIndex("MaSP");

                    b.ToTable("PhieuXuatChiTiet");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuXuatModel", b =>
                {
                    b.Property<int>("MaPhieuXuat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhieuXuat"), 1L, 1);

                    b.Property<string>("Ghichu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaKH")
                        .HasColumnType("int");

                    b.Property<int>("MaKho")
                        .HasColumnType("int");

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayXuat")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaPhieuXuat");

                    b.HasIndex("MaKH");

                    b.HasIndex("MaKho");

                    b.HasIndex("MaNhanVien");

                    b.ToTable("PhieuXuat");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.SanPhamModel", b =>
                {
                    b.Property<int>("MaSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSP"), 1L, 1);

                    b.Property<decimal>("DonGiaNhap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DonGiaXuat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaKho")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NhaSanXuat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSP");

                    b.HasIndex("MaKho");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuNhapChiTietModel", b =>
                {
                    b.HasOne("QuanLyKhoThucPham.Models.PhieuNhapModel", "PhieuNhap")
                        .WithMany("DSChiTietPhieuNhap")
                        .HasForeignKey("MaPhieuNhap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhoThucPham.Models.SanPhamModel", "SanPham")
                        .WithMany("PhieuNhapChiTiets")
                        .HasForeignKey("MaSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuNhap");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuNhapModel", b =>
                {
                    b.HasOne("QuanLyKhoThucPham.Models.KhoHangModel", "KhoHang")
                        .WithMany()
                        .HasForeignKey("MaKho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhoThucPham.Models.NhaCungCapModel", "NhaCungCap")
                        .WithMany("PhieuNhap")
                        .HasForeignKey("MaNhaCungCap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhoThucPham.Models.NhanVienModel", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhoHang");

                    b.Navigation("NhaCungCap");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuXuatChiTietModel", b =>
                {
                    b.HasOne("QuanLyKhoThucPham.Models.PhieuXuatModel", "PhieuXuat")
                        .WithMany("DSChiTietPhieuXuat")
                        .HasForeignKey("MaPhieuXuat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhoThucPham.Models.SanPhamModel", "SanPham")
                        .WithMany("PhieuXuatChiTiets")
                        .HasForeignKey("MaSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuXuat");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuXuatModel", b =>
                {
                    b.HasOne("QuanLyKhoThucPham.Models.KhachHangModel", "KhachHang")
                        .WithMany()
                        .HasForeignKey("MaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhoThucPham.Models.KhoHangModel", "KhoHang")
                        .WithMany()
                        .HasForeignKey("MaKho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKhoThucPham.Models.NhanVienModel", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("KhoHang");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.SanPhamModel", b =>
                {
                    b.HasOne("QuanLyKhoThucPham.Models.KhoHangModel", "KhoHang")
                        .WithMany("SanPhams")
                        .HasForeignKey("MaKho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhoHang");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.KhoHangModel", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.NhaCungCapModel", b =>
                {
                    b.Navigation("PhieuNhap");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuNhapModel", b =>
                {
                    b.Navigation("DSChiTietPhieuNhap");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.PhieuXuatModel", b =>
                {
                    b.Navigation("DSChiTietPhieuXuat");
                });

            modelBuilder.Entity("QuanLyKhoThucPham.Models.SanPhamModel", b =>
                {
                    b.Navigation("PhieuNhapChiTiets");

                    b.Navigation("PhieuXuatChiTiets");
                });
#pragma warning restore 612, 618
        }
    }
}
